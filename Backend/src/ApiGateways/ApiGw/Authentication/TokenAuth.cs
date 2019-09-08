using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using ApiGw.Authentication.Models;
using Microsoft.IdentityModel.Tokens;

namespace ApiGw.Authentication
{
    public static class TokenAuth
    {
        public static string GenerateBearerToken(string secret, AuthModel jwt)
        {

            var userClaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.GivenName, jwt.Nome),
                new Claim(JwtRegisteredClaimNames.Email, jwt.Email),
            };

            foreach (var permission in jwt.Claims)
            {
                userClaims.Add(new Claim(permission.Funcionalidade, permission.Permissao));
            }

            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(userClaims),
                //Issuer = "SGQ ApiGw",
                //Audience = "https://sgq.com",
                NotBefore = DateTime.Now,
                Expires = DateTime.UtcNow.AddDays(1),
                //Claims = jwt.Claims,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public static AuthModel GetTokenAuthModel(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var claims = handler.ReadJwtToken(token).Claims.ToArray();
            var jwtModel = new AuthModel
            {
                Nome = claims[0].Value,
                Email = claims[1].Value,
            };
            return jwtModel;
        }
    }
}
