using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Plantas.DTO
{
    public class PlantDTO
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id {get; set;}
        public string? Name{ get; set; }
        public string? Description{ get; set; }
        public IFormFile? Image { get; set; }
    }
}