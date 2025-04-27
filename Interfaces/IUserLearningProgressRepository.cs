using QuizletClone.Models;

namespace QuizletClone.Interfaces
{
	public interface IUserLearningProgressRepository
	{
		Task<UserLearningProgress?> GetProgressAsync(string userId, int courseId);
	}
}
