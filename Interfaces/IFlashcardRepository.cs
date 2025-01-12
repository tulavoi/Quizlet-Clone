using SmartCards.DTOs.Flashcard;
using SmartCards.Helpers;
using SmartCards.Models;

namespace SmartCards.Interfaces
{
    public interface IFlashcardRepository
    {
        Task<Flashcard> GetCurrentDisplayedAsync(string userId, int courseId);
        Task<List<Flashcard>> GetAllInCourseAsync(string userId, int courseId, FlashcardQueryObject query); 
    }
}
