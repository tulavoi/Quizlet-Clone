using QuizletClone.DTOs.Flashcard;
using QuizletClone.Models;

namespace QuizletClone.DTOs.Course
{
	public class CourseInFolderDTO
	{
		public int Id { get; set; }
		public string Title { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
		public string OwnerUserId { get; set; } = string.Empty;
		public string OwnerUsername { get; set; } = string.Empty;
		public DateTime UpdatedAt { get; set; }
        public int FlashcardCount { get; set; }
        public PermissionType? ViewPermissionType { get; set; }
	}
}
