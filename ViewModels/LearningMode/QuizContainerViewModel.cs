using QuizletClone.DTOs.LearningMode;

namespace QuizletClone.ViewModels.LearningMode
{
	public class QuizContainerViewModel
	{
		public int CourseId { get; set; }
		public List<QuestionDTO> AllQuestions { get; set; } = new();
		public int CorrectAnswerCount { get; set; }
		public int CurrentQuestionIndex { get; set; }
	}
}
