using BuildingBlocks.EventBus.Abstractions;
using DT.API.Entities;
using DT.API.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace DT.API.Infrastructure.Services
{
    public class DTService : IDTService
    {
        private readonly IDTRepository _dtRepository;
        private readonly IEventBus _eventBus;
        private readonly ILogger<DTService> _logger;

        public DTService(
            IDTRepository dtRepository,
            IEventBus eventBus,
            ILogger<DTService> logger)
        {
            _dtRepository = dtRepository ?? throw new ArgumentNullException(nameof(dtRepository));
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Divulgacao> GetDivulgacaoAsync(Guid id)
        {
            return await _dtRepository.GetDivulgacaoAsync(id);
        }

        public async Task<List<Divulgacao>> GetAllDivulgacaoAsync()
        {
            return await _dtRepository.GetDivulgacaoListAsync();
        }

        public async Task<bool> AddDivulgacaoAsync(Divulgacao divulgacao)
        {
            await _dtRepository.AddDivulgacaoAsync(divulgacao);
            return true;
        }

        public async Task<bool> UpdateDivulgacaoAsync(Divulgacao divulgacao)
        {
            await _dtRepository.UpdateDivulgacaoAsync(divulgacao);
            return true;
        }

    }
}
