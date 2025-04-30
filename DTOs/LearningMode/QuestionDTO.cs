using QuizletClone.Helpers;

namespace QuizletClone.DTOs.LearningMode
{
	public abstract class QuestionDTO
	{
		public string Question { get; set; } = string.Empty;
		public QuestionType QuestionType { get; set; }
	}
}
