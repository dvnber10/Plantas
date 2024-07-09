using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Plantas.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Plantas.Repositories
{
    public class DataCollection : DataInterface
    {
        internal Context _context= new Context();
        private IMongoCollection<Plant> collection;
        public DataCollection(){
            collection = _context.db.GetCollection<Plant>("Plant");
        }
        public async Task<List<Plant>> GetAllPlants(){
            return await collection.FindAsync(new BsonDocument()).Result.ToListAsync();
            
        } 
        public async Task InsertPlant(Plant plant){
            await collection.InsertOneAsync(plant);
        }
        public async Task UpdatePlant(Plant plant){
            var filter = Builders<Plant>.Filter.Eq(s=> s.Id , plant.Id);
            await collection.ReplaceOneAsync(filter,plant);  
        }
        public async Task  DeletePlant(string Id){
            var filter = Builders<Plant>.Filter.Eq(s => s.Id,Id);
            await collection.DeleteOneAsync(filter);
        }
        public async Task<Plant> GetPlantById(string id){
            return await collection.FindAsync(new BsonDocument{{"_id", new ObjectId(id)}}).Result.FirstOrDefaultAsync();
        }          
    }
}