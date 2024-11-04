
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Plantas.Models
{
    public class Family
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? FamilyName { get; set; }
    }
}