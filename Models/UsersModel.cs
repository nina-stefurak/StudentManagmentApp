using System.ComponentModel.DataAnnotations;

namespace StudentManagmentApp.Models
{
    public class UsersModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100,ErrorMessage = "The {0} value cannot exceed {1} characters or be less than {2} characters.", MinimumLength = 2)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} value cannot exceed {1} characters or be less than {2} characters.", MinimumLength = 2)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Technologies { get; set; }
        public string ProgrammingLanguages { get; set; }
        public string SkillsRating { get; set; }
    }
}
