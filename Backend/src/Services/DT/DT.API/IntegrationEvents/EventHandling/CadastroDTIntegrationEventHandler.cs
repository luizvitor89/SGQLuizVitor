using BuildingBlocks.EventBus.Abstractions;
using DT.API.Entities;
using DT.API.Helper;
using DT.API.Infrastructure.Services;
using DT.API.IntegrationEvents.Events;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DT.API.IntegrationEvents.EventHandling
{
    public class CadastroDTIntegrationEventHandler : IIntegrationEventHandler<CadastroDTIntegrationEvent>
    {
        private readonly ILogger<CadastroDTIntegrationEventHandler> _logger;
        private readonly IDTService _dtService;
        public CadastroDTIntegrationEventHandler(
            ILogger<CadastroDTIntegrationEventHandler> logger,
            IDTService dtService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _dtService = dtService;
        }

        public async Task Handle(CadastroDTIntegrationEvent @event)
        {
            _logger.LogInformation("----- Handling integration event: {IntegrationEventId} - ({@IntegrationEvent})", @event.Id, @event);
            
            var divulgacao = new Divulgacao() {
                OcorrenciaId = @event.OcorrenciaId,
                Consequencias = @event.Consequencias,
                CorpoDivulgacao = @event.CorpoDivulgacao,
                DataHora = @event.DataHora,
                Descricao = @event.Descricao,
                DivulgadoExternamente = @event.DivulgadoExternamente,
                DivulgadoInternamente = @event.DivulgadoInternamente,
                EmissorId = @event.EmissorId,
                Id = @event.Id,
                Resumo = @event.Resumo,
                Titulo = @event.Titulo

            };
            await _dtService.AddDivulgacaoAsync(divulgacao);
        }
    }
}
