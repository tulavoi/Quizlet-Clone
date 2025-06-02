using QuizletClone.DTOs.Flashcard;
using QuizletClone.Helpers;

namespace QuizletClone.DTOs.LearningMode
{
	public abstract class QuestionDTO
	{
		public FlashcardDTO Flashcard { get; set; } = new();
		public string Question { get; set; } = string.Empty;
		public QuestionType QuestionType { get; set; }
	}
}
