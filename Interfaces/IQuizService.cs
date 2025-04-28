using QuizletClone.DTOs.LearningMode;

namespace QuizletClone.Interfaces
{
	public interface IQuizService
	{
		Task<LearningQuestionDTO> GenerateQuestionDTOsAsync(string userId, int courseId);
	}
}
