using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizletClone.Models
{
    [Table("CourseFolder")]
    public class CourseFolder
    {
        [Required]
        public int CourseId { get; set; }
        public Course? Course { get; set; }

        [Required]
        public int FolderId { get; set; }
        public Folder? Folder { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
	}
}
