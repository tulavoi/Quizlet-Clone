using QuizletClone.DTOs.LearningMode;
using QuizletClone.Helpers;

namespace QuizletClone.Interfaces
{
	public interface IQuestionService
	{
		Task<LearningQuestionDTO> GenerateQuestionDTOsAsync(string userId, int courseId, LearningModeQueryObject queryObject);
	}
}
