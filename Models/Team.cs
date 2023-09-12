using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using StudentProjectManager.Models.auth;

namespace StudentProjectManager.Models
{
    public class Team
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public List<string> MemberUserIds { get; set; } = new List<string>();


        public string TeamLeaderId { get; set; }

        public List<string> GetCapabilities(List<ApplicationUser> members)
        {
            return members.SelectMany(member => member.Capabilities).Distinct().ToList();
        }

        public List<string> GetPositions(List<ApplicationUser> members)
        {
            return members.Select(member => member.Position).Distinct().ToList();
        }
    }
}
