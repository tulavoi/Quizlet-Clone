using QuizletClone.DTOs.Flashcard;
using QuizletClone.DTOs.LearningMode;

namespace QuizletClone.DTOs.Course
{
    public class LearningModeDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Slug { get; set; } = string.Empty;
        public LearningQuestionDTO LearningQuestion { get; set; } = new();
    }
}
