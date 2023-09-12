using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace StudentProjectManager.Models.auth
{
    public class ApplicationRole
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public string NormalizedName { get; set; }
    }

}
