using DT.API.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DT.API.Infrastructure.Repositories
{
    public class DTRepository
        : IDTRepository
    {
        private readonly DTContext _context;

        public DTRepository(IOptions<DTSettings> settings)
        {
            _context = new DTContext(settings);
        }

        public async Task<Divulgacao> GetDivulgacaoAsync(Guid id)
        {
            var filter = Builders<Divulgacao>.Filter.Eq("DivulgacaoId", id);
            return await _context.Divulgacao
                                 .Find(filter)
                                 .FirstOrDefaultAsync();
        }

        public async Task<List<Divulgacao>> GetDivulgacaoListAsync()
        {
            return await _context.Divulgacao.Find(new BsonDocument()).ToListAsync();
        }

        public async Task AddDivulgacaoAsync(Divulgacao divulgacao)
        {
            await _context.Divulgacao.InsertOneAsync(divulgacao);
        }

        public async Task UpdateDivulgacaoAsync(Divulgacao divulgacao)
        {
            await _context.Divulgacao.ReplaceOneAsync(
                doc => doc.Id == divulgacao.Id,
                divulgacao,
                new UpdateOptions { IsUpsert = true });
        }
    }
}
