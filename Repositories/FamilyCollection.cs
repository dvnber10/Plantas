using MongoDB.Bson;
using MongoDB.Driver;
using Plantas.Models;

namespace Plantas.Repositories
{
    public class FamilyCollection: FamilyInterface
    {
        internal Context _context= new Context();
        private IMongoCollection<Family> collection;
        public FamilyCollection(){
            collection = _context.db.GetCollection<Family>("Family");
        }

        public async Task CreateFamily(Family family){
            await collection.InsertOneAsync(family);
        }
        public async Task UpdateFamily (Family family){
            var filter = Builders<Family>.Filter.Eq(s=> s.Id , family.Id);
            await collection.ReplaceOneAsync(filter,family);  
        }
        public async Task  DeleteFamily(string Id){
            var filter = Builders<Family>.Filter.Eq(s => s.Id,Id);
            await collection.DeleteOneAsync(filter);
        }

        public async Task<Family> GetFamily (string Id){
            return await collection.FindAsync(new BsonDocument{{"_id", new ObjectId(Id)}}).Result.FirstOrDefaultAsync();
        }
    }
}