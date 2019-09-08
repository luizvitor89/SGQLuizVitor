using DT.API.Entities;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DT.API.Infrastructure.Repositories
{
    public interface IDTRepository
    {
        Task<Divulgacao> GetDivulgacaoAsync(Guid id);

        Task<List<Divulgacao>> GetDivulgacaoListAsync();

        Task AddDivulgacaoAsync(Divulgacao divulgacao);

        Task UpdateDivulgacaoAsync(Divulgacao divulgacao);

    }
}
