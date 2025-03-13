using QuizletClone.DTOs.Flashcard;
using QuizletClone.Models;

namespace QuizletClone.Interfaces
{
    public interface IUserFlashcardProgressRepository
    {
        Task<List<UserFlashcardProgress>> GetByIdAsync(string userId, int courseId);
        Task SaveLearnedCardAsync(string userId, int flashcardId);
        Task SaveLastReviewdCardAsync(string userId, int flashcardId);
        Task StarredFlashcardAsync(string userId, StarredFlashcardRequestDTO request);
    }
}
