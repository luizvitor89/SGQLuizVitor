using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CIP.API.Entities
{
    public class Cronograma
    {
        [Key]
        public Guid CronogramaId { get; set; }
        public Guid OcorrenciaId { get; set; }
        public DateTime DataHoraAcao { get; set; }
        public int Etapa { get; set; }
        public string PlanoDeAcao { get; set; }
        public string Norma { get; set; }
        public bool Executado { get; set; }
        public string Resultado { get; set; }

    }
}
