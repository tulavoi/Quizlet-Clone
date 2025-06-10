using QuizletClone.Models;

namespace QuizletClone.Interfaces
{
	public interface IUserLearningProgressRepository
	{
		Task<UserLearningProgress?> GetProgressAsync(string userId, int courseId);
		Task CreateAsync(UserLearningProgress progress);
		Task UpdateAsync(UserLearningProgress progress);
	}
}
