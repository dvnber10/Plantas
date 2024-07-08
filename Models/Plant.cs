using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Plantas.Models
{
    public class Plant
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id {get; set;}
        public string? Name{ get; set; }
        public string? Description{ get; set; }
        public IFormFile? Imagen { get; set; }

    }
}