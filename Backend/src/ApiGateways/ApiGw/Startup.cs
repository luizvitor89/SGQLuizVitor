using System;
using System.Text;
using ApiGw.Config;
using ApiGw.Infrastructure;
using ApiGw.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace ApiGw
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "GW API",
                    Description = "POC SQG Luiz Vitor. Acesso sistema, email:luiz@sgq.com senha:123456",
                    //TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Luiz Vitor",
                        Email = "luizvitor89@gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/luiz-vitor-ramos-silva-29350397/"),
                    }
                    //,License = new OpenApiLicense{Name = "Use under LICX",Url = new Uri("https://example.com/license"),}
                });
            });
            services.AddOcelot(Configuration);
            services.Configure<UrlsConfig>(Configuration.GetSection("urls"));

            services.AddTransient<HttpClientAuthorizationDelegatingHandler>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddHttpClient<ICIPService, CIPService>()
                .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

            #region Authentication Token JWT

            var key = Encoding.ASCII.GetBytes(Configuration["JtwTokenSecret"]);

            services.AddAuthentication(a =>
            {
                a.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                a.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(t =>
                {
                    t.RequireHttpsMetadata = false;
                    t.SaveToken = true;
                    t.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(key),

                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,

                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());

                options.AddPolicy("DTCadastrar", policy => policy.RequireClaim("DT", "Cadastrar"));
                options.AddPolicy("DTVisualizar", policy => policy.RequireClaim("DT", "Visualizar"));

                options.AddPolicy("CIPCadastrar", policy => policy.RequireClaim("CIP", "Cadastrar"));
                options.AddPolicy("CIPVisualizar", policy => policy.RequireClaim("CIP", "Visualizar"));

            });
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            app.UseAuthentication();
            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "GW API");
                c.RoutePrefix = string.Empty;
            });

            app.UseMvc();

            app.UseOcelot().Wait();
        }
    }
}
