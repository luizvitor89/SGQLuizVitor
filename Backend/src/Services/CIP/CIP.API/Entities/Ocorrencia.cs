using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CIP.API.Entities
{
    public class Ocorrencia
    {
        [Key]
        public Guid OcorrenciaId { get; set; }
        public Guid TipoOcorrenciaId { get; set; }
        [ForeignKey("TipoOcorrenciaId")] //public virtual TipoOcorrencia FKTipoOcorrencia { get; set; }
        public Guid InsumoId { get; set; }
        [ForeignKey("InsumoId")] //public virtual Insumo FKTipoInsumo { get; set; }
        public Guid EmissorId { get; set; }
        [ForeignKey("EmissorId")] //public virtual Emissor FKEmissor { get; set; }
        public Guid SetorId { get; set; }
        [ForeignKey("SetorId")] //public virtual Setor FKSetor { get; set; }
        public Guid StatusId { get; set; }
        [ForeignKey("StatusId")] //public virtual Status FKStatus { get; set; }
        public string Titulo { get; set; }
        public DateTime DataHora { get; set; }
        public string Descricao { get; set; }
        public string Consequencias { get; set; }
        public int Prioridade { get; set; }
        public bool Ativo { get; set; }
        public bool DivulgadoInternamente { get; set; }
        public bool DivulgadoExternamente { get; set; }


    }
}
