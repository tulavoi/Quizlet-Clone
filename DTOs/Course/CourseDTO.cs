using QuizletClone.Areas.Identity.Data;
using QuizletClone.DTOs.Flashcard;
using QuizletClone.Models;

namespace QuizletClone.DTOs.Course
{
    public class CourseDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string? Password { get; set; } = string.Empty;
        public string? Slug { get; set; } = string.Empty;
        public string OwnerUserId { get; set; } = string.Empty;
        public string OwnerUsername { get; set; } = string.Empty;
        public string RelativeTime { get; set; } = string.Empty;
        public List<FlashcardDTO> Flashcards { get; set; } = new List<FlashcardDTO>();
        public List<FlashcardDTO>? LearnedFlashcards { get; set; } = new List<FlashcardDTO>();
        public List<FlashcardDTO>? NotLearnedFlashcards { get; set; } = new List<FlashcardDTO>();
        public FlashcardDTO? LastLearnedFlashcard { get; set; }
        public int StarredFlashcardCount { get; set; }
        public int FlashcardCount { get; set; }
        public bool IsShuffle { get; set; }
    }
}
