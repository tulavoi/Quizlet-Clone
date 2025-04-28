namespace QuizletClone.DTOs.LearningMode
{
	public class MultipleChoiceQuestionDTO
	{
		public string Question { get; set; } = string.Empty;
		public List<string> Answers { get; set; } = new();
		public string CorrectAnswer { get; set; } = string.Empty;
	}
}
