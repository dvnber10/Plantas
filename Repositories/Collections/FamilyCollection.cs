using MongoDB.Bson;
using MongoDB.Driver;
using Plantas.Models;
using Plantas.Repositories.Interfaces;

namespace Plantas.Repositories
{
    public class FamilyCollection : FamilyInterface<Family>, VerInterface
    {
        private readonly IMongoCollection<Family> _collection;
        public FamilyCollection(Context context)
        {
            _collection = context.GetCollection<Family>("Family");
        }

        public async Task CreateFamily(Family family)
        {
            await _collection.InsertOneAsync(family);
        }

        public async Task DeleteFamily(string Id)
        {
            var filter = Builders<Family>.Filter.Eq(s => s.Id, Id);
            await _collection.DeleteOneAsync(filter);
        }

        public async Task<Family> GetFamily(string Id)
        {
            return await _collection.FindAsync(new BsonDocument { { "_id", new ObjectId(Id) } }).Result.FirstOrDefaultAsync();
        }

        public async Task UpdateFamily(Family family)
        {
            var filter = Builders<Family>.Filter.Eq(s => s.Id, family.Id);
            await _collection.ReplaceOneAsync(filter, family);
        }
        public async Task Ver(string id)
        {
            var filter = Builders<Family>.Filter.Eq(s => s.Id, id);
            await _collection.DeleteOneAsync(filter);
        }
    }
}