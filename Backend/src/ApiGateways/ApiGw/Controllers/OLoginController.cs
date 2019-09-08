using System.Collections.Generic;
using System.Threading.Tasks;
using ApiGw.Authentication;
using ApiGw.Authentication.Models;
using ApiGw.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ApiGw.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OLoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ICIPService _cipService;
        public OLoginController(IConfiguration configuration,
            ICIPService cipService)
        {
            _configuration = configuration;
            _cipService = cipService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<AuthModel>> Login(AuthModel authModel)
        {
            var retorno = await _cipService.EmissorLoginAsync(authModel);

            if (retorno.Email == null)
            {
                return BadRequest("Email ou senha invalidos");
            }

            authModel.Email = retorno.Email;
            authModel.Nome = retorno.Nome;
            authModel.Senha = null;
            authModel.Claims = new List<UserPermissionModel>();

            if (retorno.PermissaoCadastro)
            {
                authModel.Claims.Add(new UserPermissionModel() { Funcionalidade = "DT", Permissao = "Cadastrar" });
                authModel.Claims.Add(new UserPermissionModel() { Funcionalidade = "CIP", Permissao = "Cadastrar" });
            }

            if (retorno.PermissaoVisualizacao)
            {
                authModel.Claims.Add(new UserPermissionModel() { Funcionalidade = "DT", Permissao = "Visualizar" });
                authModel.Claims.Add(new UserPermissionModel() { Funcionalidade = "CIP", Permissao = "Visualizar" });
            }

            authModel.Token = TokenAuth.GenerateBearerToken(_configuration["JtwTokenSecret"], authModel);

            return authModel;
        }
    }
}