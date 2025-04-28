namespace QuizletClone.DTOs.LearningMode
{
	public class EssayQuestionDTO
	{
		public string Question { get; set; } = string.Empty;
		public string CorrectAnswer { get; set; } = string.Empty;
		public List<char> CharacterBank = new();
	}
}
