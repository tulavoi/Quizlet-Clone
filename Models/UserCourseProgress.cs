using QuizletClone.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizletClone.Models
{
    [Table("UserCourseProgress")]
    public class UserCourseProgress
    {
        [Required]
        public string UserId { get; set; } = string.Empty;
        public AppUser? User { get; set; }

        [Required]
        public int CourseId { get; set; }
        public Course? Course { get; set; }

        public bool IsShuffle { get; set; } = false;

        public DateTime LastUpdated { get; set; } = DateTime.Now;
    }
}
