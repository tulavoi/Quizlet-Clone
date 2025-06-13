using Microsoft.EntityFrameworkCore;
using QuizletClone.Areas.Identity.Data;
using QuizletClone.DTOs.Flashcard;
using QuizletClone.Helpers;
using QuizletClone.Interfaces;
using QuizletClone.Models;

namespace QuizletClone.Repositories
{
    public class FlashcardRepository : IFlashcardRepository
    {
        private readonly AppDbContext _context;
        public FlashcardRepository(AppDbContext context)
        {
            _context = context;
        }

        // Lấy ra flashcard đang hiển thị ở lần truy cập trước
        public async Task<Flashcard?> GetMostRecentlyAsync(string userId, int courseId)
        {
            return await _context.UserFlashcardProgresses
                .Where(x => x.UserId == userId && x.Flashcard.CourseId == courseId && x.LastReviewedAt != null)
                .OrderByDescending(x => x.LastReviewedAt)
                .Select(x => x.Flashcard)
                .FirstOrDefaultAsync() ?? null;
        }

        // Lấy tất cả flashcard
        public async Task<List<Flashcard>?> GetAllCardsInCourseAsync(string userId, int courseId, FlashcardQueryObject query)
        {
            var queryable = _context.Flashcards
                .Where(fc => fc.CourseId == courseId)

                // Left join với UserFlashcardProgresses của user để lấy tiến độ học 
                // tương ứng với mỗi flashcard
                .GroupJoin(
                    _context.UserFlashcardProgresses
                        .Where(p => p.UserId == userId),        // dữ liệu bên phải: tiến độ học của user 
                    flashcard => flashcard.Id,                  // khóa bên trái: flashcard.CourseId\
                    progress => progress.FlashcardId,           // khóa bên phải: progress.FlashcardId
                    (flashcard, progresses) => new              // kết quả sau khi join
                    {
                        flashcard,                              // flashcard
                        progress = progresses.FirstOrDefault()  // lấy ra tiến độ nếu có (hoặc null nếu chưa học)
                    }
                );

            if (query.IsLearned.HasValue)
            {
                queryable = queryable.Where(fp =>
                    (query.IsLearned.Value && fp.progress != null && fp.progress.IsLearned) ||
                    (!query.IsLearned.Value && (fp.progress == null || !fp.progress.IsLearned))
                );
            }

            if (query.IsStarred.HasValue)
            {
                queryable = queryable.Where(fp => fp.progress != null && fp.progress.IsStarred == query.IsStarred.Value);
            }

            return await queryable.Select(fp => fp.flashcard).ToListAsync();
        }

        public async Task UpdateAsync(UpdateFlashcardRequestDTO flashcardDTO)
        {
            var flashcard = await _context.Flashcards.FindAsync(flashcardDTO.Id);
            if (flashcard == null) return;

            flashcard.Term = flashcardDTO.Term;
            flashcard.Definition = flashcardDTO.Definition;
            flashcard.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();
        }
    }
}
