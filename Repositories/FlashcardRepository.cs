using Microsoft.EntityFrameworkCore;
using SmartCards.Areas.Identity.Data;
using SmartCards.Helpers;
using SmartCards.Interfaces;
using SmartCards.Models;
using System.Net.Quic;
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

        public async Task<Flashcard> GetLastLearnedAsync(FlashcardQueryObject query)
        {
            return await _context.UserFlashcardProgresses
                .Where(x => x.UserId == query.UserId && x.IsLearned && x.Flashcard.CourseId == query.CourseId)
                .OrderByDescending(x => x.LastReviewedAt)
                .Select(x => x.Flashcard)
                .FirstOrDefaultAsync() ?? new Flashcard();
        }

        public async Task<List<Flashcard?>> GetAllInCourseAsync(FlashcardQueryObject query)
        {
            //return await _context.UserFlashcardProgresses
            //    .Include(x => x.Flashcard)
            //    .Where(x => x.UserId == query.UserId
            //        && x.IsLearned == query.IsLearned
            //        && x.Flashcard.CourseId == query.CourseId)
            //    .Select(x => x.Flashcard)
            //    .ToListAsync();

            // Lấy tất cả flashcard trong khóa học
            var allFlashcardsInCourse = _context.Flashcards
                .Where(x => x.CourseId == query.CourseId);

            // Lấy thông tin UserFlashcardProgresses cho người dùng trong khóa học
            var userProgresses = _context.UserFlashcardProgresses
                .Where(up => up.UserId == query.UserId && up.Flashcard.CourseId == query.CourseId);

            // Kết hợp 2 nguồn dữ liệu
            var result = from flashcard in allFlashcardsInCourse
                         join progress in userProgresses
                         on flashcard.Id equals progress.FlashcardId into progressGroup
                         from progress in progressGroup.DefaultIfEmpty() // Left join
                         where (query.IsLearned && progress != null && progress.IsLearned) // Lấy flashcards đã học
                        || (!query.IsLearned && (progress == null || !progress.IsLearned)) // Lấy flashcards chưa học
                         select flashcard;

            return await result.ToListAsync();
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
