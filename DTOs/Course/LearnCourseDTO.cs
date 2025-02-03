using SmartCards.DTOs.Flashcard;

namespace SmartCards.DTOs.Course
{
    public class LearnCourseDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Slug { get; set; } = string.Empty;
        public List<FlashcardDTO> Flashcards { get; set; } = new List<FlashcardDTO>();
    }
}
