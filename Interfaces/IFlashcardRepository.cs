using QuizletClone.DTOs.Flashcard;
using QuizletClone.Helpers;
using QuizletClone.Models;

namespace QuizletClone.Interfaces
{
    public interface IFlashcardRepository
    {
        Task<Flashcard?> GetCurrentDisplayedAsync(string userId, int courseId);
        Task<List<Flashcard>> GetAllCardsInCourseAsync(string userId, int courseId, FlashcardQueryObject query);
        Task<List<Flashcard>> GetStarredCardsInCourseAsync(string userId, int courseId, FlashcardQueryObject flashcardQueryObject);
        Task UpdateAsync(UpdateFlashcardRequestDTO flashcardDTO);
    }
}
