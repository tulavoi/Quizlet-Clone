namespace QuizletClone.DTOs.LearningMode
{
	public class MultipleChoiceQuestionDTO : QuestionDTO
	{
		public List<string> Options { get; set; } = new();
		public string CorrectOption { get; set; } = string.Empty;
	}
}
