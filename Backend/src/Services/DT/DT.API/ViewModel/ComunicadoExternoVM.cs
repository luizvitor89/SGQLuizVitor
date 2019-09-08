using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DT.API.ViewModel
{
    public class ComunicadoExternoVM
    {
        public Guid Id { get; set; }
        public Guid OcorrenciaId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Resumo { get; set; }
        public string Consequencias { get; set; }
        public string CorpoDivulgacao { get; set; }
        public DateTime DataHora { get; set; }
    }
}
