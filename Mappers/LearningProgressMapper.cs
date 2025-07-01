using QuizletClone.DTOs.LearningMode;
using QuizletClone.Models;

namespace QuizletClone.Mappers
{
	public static class LearningProgressMapper
	{
		public static UserLearningProgress ToLearningProgressFromUpdateDTO(this UpdateLearningProgressRequestDTO requestDTO)
		{
			return new UserLearningProgress
			{
				UserId = requestDTO.UserId,
				CourseId = requestDTO.CourseId,
				CorrectAnswerCount = requestDTO.CorrectAnswerCount,
				CurrentQuestionIndex = requestDTO.CurrentQuestionIndex,
				CorrectAnswersPerStep = requestDTO.CorrectAnswersPerStep,
				LastAccessed = requestDTO.LastAccessed,
				QuestionType = requestDTO.QuestionType
			};
		}
	}
}
