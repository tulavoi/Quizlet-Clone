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

        public async Task<UserLearningProgress?> GetProgressAsync(string userId, int courseId)
		{
			return await _context.UserLearningProgresses
				.FirstOrDefaultAsync(ulp => ulp.UserId == userId && ulp.CourseId == courseId);
		}
	}
}
