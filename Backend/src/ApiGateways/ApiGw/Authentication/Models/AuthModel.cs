using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGw.Authentication.Models
{
    public class AuthModel
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Token { get; set; }
        public List<UserPermissionModel> Claims { get; set; }
    }

    public class UserPermissionModel
    {
        public string Funcionalidade { get; set; }
        public string Permissao { get; set; }
    }
}
