using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CIP.API.Entities
{
    public class Insumo
    {
        [Key]
        public Guid InsumoId { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
    }
}
