using Microsoft.EntityFrameworkCore;
using SmartCards.Areas.Identity.Data;
using SmartCards.Interfaces;
using SmartCards.Models;
using System.Net.WebSockets;

namespace SmartCards.Repositories
{
    public class FlashcardRepository : IFlashcardRepository
    {
        private readonly AppDbContext _context;
        public FlashcardRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Flashcard> GetLastLearnedAsync(string userId, int courseId)
        {
            return await _context.UserFlashcardProgresses
                .Include(x => x.Flashcard)
                .Where(x => x.UserId == userId && x.IsLearned && x.Flashcard.CourseId == courseId)
                .OrderByDescending(x => x.LastReviewedAt)
                .Select(x => x.Flashcard)
                .FirstOrDefaultAsync() ?? new Flashcard();
        }

        public async Task SaveLastLearnedAsync(string userId, int flashcardId)
        {
            // Kiểm tra xem user đã học flashcard này hay chưa
            var progress = await _context.UserFlashcardProgresses
                .FirstOrDefaultAsync(x => x.UserId == userId && x.FlashcardId == flashcardId);

            if (progress != null) return;

            // Nếu chưa thì tiến hành thêm mới
            else
            {
                _context.UserFlashcardProgresses.Add(new UserFlashcardProgress
                {
                    UserId = userId,
                    FlashcardId = flashcardId,
                    IsLearned = true,
                    LastReviewedAt = DateTime.Now
                });
            }

            await _context.SaveChangesAsync();
        }
    }
}
