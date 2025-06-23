using QuizletClone.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace QuizletClone.Models
{
	public class UserLearningProgress
	{
		[Required]
		public AppUser? User { get; set; }
		public string UserId { get; set; } = string.Empty;

		[Required]
		public Course? Course { get; set; }
		public int CourseId { get; set; }

		public int CorrectAnswerCount { get; set; } = 0;
		public int CurrentQuestionIndex { get; set; } = 0;
		public string CorrectAnswersPerStep { get; set; } = string.Empty;
		public DateTime LastAccessed { get; set; } = DateTime.Now;
	}
}
