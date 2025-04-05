using QuizletClone.DTOs.Flashcard;
using QuizletClone.Helpers;
using QuizletClone.Models;

namespace QuizletClone.Interfaces
{
    public interface IFlashcardRepository
    {
        Task<Flashcard?> GetMostRecentlyAsync(string userId, int courseId);
        Task<List<Flashcard>> GetAllCardsInCourseAsync(string userId, int courseId, FlashcardQueryObject query);
        Task UpdateAsync(UpdateFlashcardRequestDTO flashcardDTO);
    }
}
