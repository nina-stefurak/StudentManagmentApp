using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;


namespace StudentProjectManager.Models
{
    public class Project
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Requirements { get; set; }
        public string TechnologyStack { get; set; }
        public string ProgrammingLanguages { get; set; }
        public string DifficultyLevel { get; set; }
        public DateTime EstimatedCompletionDate { get; set; }
        public DateTime SubmissionDate { get; set; }
        public string TeamId { get; set; }
        public string RepositoryLink { get; set; }
        public string Status { get; set; }
        public int PrestigePoints { get; set; }
        public List<string> CandidateUserIds { get; set; } = new List<string>();

    }
}
