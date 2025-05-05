using QuizletClone.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace QuizletClone.Models
{
	public class UserLearningProgress
	{
		public int Id { get; set; }
		public int CorrectAnswerCount { get; set; } = 0;
		public int CurrentQuestionIndex { get; set; } = 0;
		public int TotalQuestions { get; set; } = 0;
		public DateTime LastAccessed { get; set; } = DateTime.Now;

        [Required]
		public AppUser? User { get; set; }
		public string UserId { get; set; } = string.Empty;

        [Required]
		public Course? Course { get; set; }
		public int CourseId { get; set; }
	}
}
