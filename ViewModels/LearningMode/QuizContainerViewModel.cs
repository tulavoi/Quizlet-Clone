using QuizletClone.DTOs.LearningMode;

namespace QuizletClone.ViewModels.LearningMode
{
	public class QuizContainerViewModel
	{
		public List<QuestionDTO> AllQuestions { get; set; } = new();
	}
}
