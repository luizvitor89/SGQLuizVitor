using DT.API.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DT.API.Infrastructure
{
    public class DTContext
    {
        private readonly IMongoDatabase _database = null;

        public DTContext(IOptions<DTSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<Divulgacao> Divulgacao
        {
            get
            {
                return _database.GetCollection<Divulgacao>("Divulgacao");
            }
        }
    }
}
