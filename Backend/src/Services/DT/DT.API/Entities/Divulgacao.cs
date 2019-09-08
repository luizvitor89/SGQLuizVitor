using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DT.API.Entities
{
    public class Divulgacao
    {
        [BsonId]
        public Guid Id { get; set; }
        public Guid OcorrenciaId { get; set; }
        public Guid EmissorId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Resumo { get; set; }
        public string Consequencias { get; set; }
        public string CorpoDivulgacao { get; set; }
        public DateTime DataHora { get; set; }
        public bool DivulgadoInternamente { get; set; }
        public bool DivulgadoExternamente { get; set; }


    }
}
