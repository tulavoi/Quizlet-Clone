namespace QuizletClone.DTOs.LearningMode
{
	public class LearningQuestionDTO
	{
		public string Question { get; set; } = string.Empty;
		public List<string> Answers { get; set; } = new();
		public string CorrectAnswer { get; set; } = string.Empty;
	}
}
