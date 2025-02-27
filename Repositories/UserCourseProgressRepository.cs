using api.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using SmartCards.Areas.Identity.Data;
using SmartCards.Interfaces;
using SmartCards.Models;

namespace SmartCards.Repositories
{
    public class UserCourseProgressRepository : IUserCourseProgressRepository
    {
        private readonly AppDbContext _context;
        public UserCourseProgressRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserCourseProgress> GetByIdAsync(string userId, int courseId)
        {
            return await _context.UserCourseProgresses
                .FirstOrDefaultAsync(x => x.UserId == userId && x.CourseId == courseId) 
                ?? new UserCourseProgress();
        }

        public async Task UpdateProgressAsync(string userId, int courseId, bool isShuffle)
        {
            var progress = await _context.UserCourseProgresses
                .FirstOrDefaultAsync(x => x.UserId == userId && x.CourseId == courseId);

            if (progress != null) 
            {
                progress.IsShuffle = isShuffle;
                progress.LastUpdated = DateTime.Now;
            } 
            else
            {
                var newProgress = new UserCourseProgress
                {
                    UserId = userId,
                    CourseId = courseId,
                    IsShuffle = isShuffle,
                    LastUpdated = DateTime.Now
                };
                _context.UserCourseProgresses.Add(newProgress);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<List<UserCourseProgress>?> GetAllByUserAsync(string userId, CourseQueryObject query)
        {
            var courseProgresses = _context.UserCourseProgresses
                        .Where(ucp => ucp.UserId == userId)
                        .Include(ucp => ucp.Course)
                            .ThenInclude(c => c.User)
                        .Include(ucp => ucp.Course)
                            .ThenInclude(c => c.Flashcards)
                                .ThenInclude(fc => fc.Term_Lang)
                        .Include(ucp => ucp.Course)
                            .ThenInclude(c => c.Flashcards)
                                .ThenInclude(fc => fc.Definition_Lang)
                        .Include(ucp => ucp.Course)
                            .ThenInclude(c => c.CoursePermission)
                                .ThenInclude(cp => cp.ViewPermission)
                        .AsQueryable();

            if (!string.IsNullOrEmpty(query.SortBy) && query.SortBy.Equals("LastUpdated", StringComparison.OrdinalIgnoreCase))
            {
                courseProgresses = query.IsDescending ? courseProgresses.OrderByDescending(ucp => ucp.LastUpdated)
                    : courseProgresses.OrderBy(ucp => ucp.LastUpdated);
            }

            // Giới hạn số lượng course nếu không lấy tất cả
            if (!query.GetAll && query.Quantity > 0)
                courseProgresses = courseProgresses.Take(query.Quantity);

            var result = await courseProgresses.ToListAsync();

            return result.Any() ? result : null;
        }
    }
}
