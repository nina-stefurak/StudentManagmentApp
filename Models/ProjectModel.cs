namespace StudentManagmentApp.Models
{
    public class ProjectModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Requirements { get; set; }
        public string ProgrammingLanguages { get; set; }
        public string TechnologyStack { get; set; }
        public string DifficultyLevel { get; set; }
        public DateTime PlannedEndDate { get; set; }
        public DateTime? ActualEndDate { get; set; }
        public string? RepositoryLink { get; set; }
        public string Status { get; set; }
        public int TeamId { get; set; }
        public string TeamName { get; set; }

    }
}
