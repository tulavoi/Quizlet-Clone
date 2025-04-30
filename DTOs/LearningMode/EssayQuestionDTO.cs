namespace QuizletClone.DTOs.LearningMode
{
	public class EssayQuestionDTO : QuestionDTO
	{
		public string CorrectAnswer { get; set; } = string.Empty;
		public List<char> CharacterBank = new();
	}
}
