using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace StudentProjectManager.Models.auth
{
    public class ApplicationUser
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string UserName { get; set; }

        public string NormalizedUserName { get; set; }

        public string PasswordHash { get; set; }

        public string Email { get; set; }

        public string NormalizedEmail { get; set; }

        public bool EmailConfirmed { get; set; }

        public List<string> Roles { get; set; }

        public List<string> Capabilities { get; set; } = new List<string>();

        public string Position { get; set; }

        public SeniorityLevel SeniorityLevel { get; set; } = SeniorityLevel.Beginner;
    }

    public enum SeniorityLevel
    {
        Beginner,
        Junior,
        Regular,
        Senior
    }
}
