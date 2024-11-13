using dotenv.net;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Plantas.Models;

namespace Plantas.Repositories
{
    public class Context
    {
        public readonly IMongoDatabase _db;
        public Context(IOptions<MongoConnections> settings)
        {
            try
            {
                var client = new MongoClient(settings.Value.ConnectionStrings);
                _db = client.GetDatabase(settings.Value.DatabaseName);
            }
            catch (MongoException ex)
            {
                System.Console.WriteLine($"Error: {ex.Message}");
            }
            catch (System.Exception ex)
            {
                throw new ApplicationException($"Algo fallo al enlazar base de datos {ex.Message}");
            }
        }

        public IMongoCollection<T> GetCollection<T>(string collection)
        {
            return _db.GetCollection<T>(collection);
        }
    }
}