using QuizletClone.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizletClone.Models
{
    [Table("Folders")]
    public class Folder
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public string Slug { get; set; } = string.Empty;

        [Required]
        public required string UserId { get; set; }
        public AppUser? User { get; set; }
        public List<CourseFolder> CourseFolders { get; set; } = new();
    }
}
