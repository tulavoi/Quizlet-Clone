using QuizletClone.DTOs.LearningMode;

namespace QuizletClone.ViewModels.LearningMode
{
	public class LearningProgressViewModel
	{
		public List<MultipleChoiceQuestionDTO> MultipleChoiceQuestions { get; set; } = new();
		public List<EssayQuestionDTO> EssayQuestions { get; set; } = new();
	}
}
