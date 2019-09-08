using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGw.ViewModels
{
    public class EmissorViewModel
    {
        public Guid EmissorId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool PermissaoVisualizacao { get; set; }
        public bool PermissaoCadastro { get; set; }
    }
}
