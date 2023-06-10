using System.ComponentModel.DataAnnotations;

namespace StudentManagmentApp.Models
{
    public class ProjectModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Requirements { get; set; }
        [Required]
        public string ProgrammingLanguages { get; set; }
        [Required]
        public string TechnologyStack { get; set; }
        [Required]
        public string DifficultyLevel { get; set; }
        [Required]
        public DateTime PlannedEndDate { get; set; }
        public DateTime? ActualEndDate { get; set; }
        public string? RepositoryLink { get; set; }
        [Required]
        public string Status { get; set; }
        public int TeamId { get; set; }
        [Required]
        public string Visibility { get; set; }
    }
}
