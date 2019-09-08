using DT.API.Entities;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DT.API.Infrastructure.Services
{
    public interface IDTService
    {
        Task<Divulgacao> GetDivulgacaoAsync(Guid id);
        Task<List<Divulgacao>> GetAllDivulgacaoAsync();
        Task<bool> AddDivulgacaoAsync(Divulgacao divulgacao);
        Task<bool> UpdateDivulgacaoAsync(Divulgacao divulgacao);
    }
}
