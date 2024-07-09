<<<<<<< HEAD
=======
using dotenv.net;
>>>>>>> 388509a71cace2343a047210e18e6f86111ebdc4
using MongoDB.Driver;

namespace Plantas.Repositories
{
    public class Context
    {
<<<<<<< HEAD
        private readonly IConfigurationRoot _config;
        public MongoClient? client;
        public IMongoDatabase? db;
        public Context (){
            IConfigurationBuilder builder = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            _config = builder.Build();

            client = new MongoClient(_config.GetConnectionString("Base"));
=======
        public MongoClient? client;
        public IMongoDatabase? db;
        public Context (){
            
            var env = DotEnv.Read();
            client = new MongoClient(env["Database"]);
>>>>>>> 388509a71cace2343a047210e18e6f86111ebdc4
            db = client.GetDatabase("Plantas");
        }
    }
}