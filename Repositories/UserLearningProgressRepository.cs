using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using QuizletClone.Areas.Identity.Data;
using QuizletClone.Interfaces;
using QuizletClone.Models;

namespace QuizletClone.Repositories
{
	public class UserLearningProgressRepository : IUserLearningProgressRepository
	{
		private readonly AppDbContext _context;

        public UserLearningProgressRepository(AppDbContext context)
        {
            _context = context;
        }

		public async Task CreateAsync(UserLearningProgress progress)
		{
			var learningProgress = new UserLearningProgress
			{
				UserId = progress.UserId,
				CourseId = progress.CourseId,
				CorrectAnswerCount = 0,
				LastAccessed = DateTime.Now
			};
			_context.UserLearningProgresses.Add(learningProgress);
			await _context.SaveChangesAsync();
		}

		public async Task<UserLearningProgress?> GetProgressAsync(string userId, int courseId)
		{
			return await _context.UserLearningProgresses
				.FirstOrDefaultAsync(ulp => ulp.UserId == userId && ulp.CourseId == courseId);
		}

		public async Task UpdateAsync(UserLearningProgress progress)
		{
			var existedProgress = await _context.UserLearningProgresses
				.FirstOrDefaultAsync(ulp => ulp.UserId == progress.UserId && ulp.CourseId == progress.CourseId);

			if (existedProgress == null) return;
		
			existedProgress.LastAccessed = DateTime.Now;
			existedProgress.CorrectAnswerCount = progress.CorrectAnswerCount;
			existedProgress.CurrentQuestionIndex = progress.CurrentQuestionIndex;
			await _context.SaveChangesAsync();
		}
	}
}
