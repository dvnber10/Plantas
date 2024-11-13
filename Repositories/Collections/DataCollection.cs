using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Plantas.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Plantas.Repositories
{
    public class DataCollection : DataInterface<Plant>
    {
        private readonly IMongoCollection<Plant> _collection;
        public DataCollection(Context context)
        {
            _collection = context.GetCollection<Plant>("Plant");
        }

        public async Task Delete(string Id)
        {
            try
            {
                var filter = Builders<Plant>.Filter.Eq(s => s.Id, Id);
                await _collection.DeleteOneAsync(filter);
            }
            catch (System.Exception ex)
            {
                throw new ApplicationException($"Hubo un error _ {ex.Message}");
            }
        }

        public async Task<List<Plant>> GetAll()
        {
            try
            {
                return await _collection.FindAsync(new BsonDocument()).Result.ToListAsync();
            }
            catch (System.Exception ex)
            {
                throw new ApplicationException($"Hubo un error _ {ex.Message}");
            }
        }

        public async Task<Plant> GetById(string id)
        {
            try
            {
                return await _collection.FindAsync(new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstOrDefaultAsync();
            }
            catch (System.Exception ex)
            {
                throw new ApplicationException($"hubo un error _ {ex.Message}");
            }
        }

        public async Task Insert(Plant Model)
        {
            try
            {
                await _collection.InsertOneAsync(Model);
            }
            catch (System.Exception ex)
            {
                throw new ApplicationException($"Hubo un error _ {ex.Message}");
            }
        }

        public async Task Update(Plant Model)
        {
            var filter = Builders<Plant>.Filter.Eq(s=> s.Id , Model.Id);
            await _collection.ReplaceOneAsync(filter,Model);
        }         
    }
}