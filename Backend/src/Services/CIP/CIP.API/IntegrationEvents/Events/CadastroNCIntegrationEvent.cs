using BuildingBlocks.EventBus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIP.API.IntegrationEvents.Events
{
    public class CadastroNCIntegrationEvent : IntegrationEvent
    {
        public int NcId { get; private set; }

        public CadastroNCIntegrationEvent(int ncId)
        {
            NcId = ncId;
        }
    }
}
