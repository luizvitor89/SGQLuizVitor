using BuildingBlocks.EventBus.Abstractions;
using CIP.API.IntegrationEvents.Events;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIP.API.IntegrationEvents.EventHandling
{
    public class CadastroNCIntegrationEventHandler : IIntegrationEventHandler<CadastroNCIntegrationEvent>
    {
        private readonly ILogger<CadastroNCIntegrationEventHandler> _logger;

        public CadastroNCIntegrationEventHandler(
            ILogger<CadastroNCIntegrationEventHandler> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Handle(CadastroNCIntegrationEvent @event)
        {
            _logger.LogInformation("----- Handling integration event: {IntegrationEventId} - ({@IntegrationEvent})", @event.Id, @event);

            //faz alguma coisa
        }
    }
}