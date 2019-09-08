using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CIP.API.Entities
{
    public class Emissor
    {
        [Key]
        public Guid EmissorId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool PermissaoVisualizacao { get; set; }
        public bool PermissaoCadastro { get; set; }
    }
}
