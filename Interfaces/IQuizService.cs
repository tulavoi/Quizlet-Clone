using QuizletClone.DTOs.LearningMode;

namespace QuizletClone.Interfaces
{
	public interface IQuizService
	{
		Task<List<LearningQuestionDTO>> GenerateQuestionDTOsAsync(string userId, int courseId);
	}
}
