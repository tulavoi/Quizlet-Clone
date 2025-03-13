using QuizletClone.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Permissions;

namespace QuizletClone.Models
{
    [Table("UserFlashcardProgress")]
    public class UserFlashcardProgress
    {
        [Required]
        public string UserId { get; set; } = string.Empty;
        public AppUser? User { get; set; }

        [Required]
        public int FlashcardId { get; set; }
        public Flashcard? Flashcard { get; set; }

        public bool IsLearned { get; set; } = false;
        public bool IsStarred { get; set; } = false;
        public DateTime? LastReviewedAt { get; set; }
    }
}
