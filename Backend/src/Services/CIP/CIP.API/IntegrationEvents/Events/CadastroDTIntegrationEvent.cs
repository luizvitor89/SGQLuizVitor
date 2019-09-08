using BuildingBlocks.EventBus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIP.API.IntegrationEvents.Events
{
    public class CadastroDTIntegrationEvent : IntegrationEvent
    {
        public new Guid Id { get; set; }
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

        public CadastroDTIntegrationEvent(Guid id, Guid ocorrenciaId, Guid emissorId,
            string titulo, string descricao, string resumo, string consequencias, string corpoDivulgacao,
            DateTime dataHora, bool divulgadoInternamente, bool divulgadoExternamente)
        {
            Id = id;
            OcorrenciaId = ocorrenciaId;
            EmissorId = emissorId;
            Titulo = titulo;
            Descricao = descricao;
            Resumo = resumo;
            Consequencias = consequencias;
            CorpoDivulgacao = corpoDivulgacao;
            DataHora = dataHora;
            DivulgadoInternamente = divulgadoInternamente;
            DivulgadoExternamente = divulgadoExternamente;
        }
    }
}
