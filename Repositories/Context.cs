using dotenv.net;
using MongoDB.Driver;

namespace Plantas.Repositories
{
    public class Context
    {
        public MongoClient? client;
        public IMongoDatabase? db;
        public Context (){
            
            var env = DotEnv.Read();
            client = new MongoClient(env["Database"]);
            db = client.GetDatabase("Plantas");
        }
    }
}