using MongoDB.Driver;

namespace Plantas.Repositories
{
    public class Context
    {
        private readonly IConfigurationRoot _config;
        public MongoClient? client;
        public IMongoDatabase? db;
        public Context (){
            IConfigurationBuilder builder = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            _config = builder.Build();

            client = new MongoClient(_config.GetConnectionString("Base"));
            db = client.GetDatabase("Plantas");
        }
    }
}