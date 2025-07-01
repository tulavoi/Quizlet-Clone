using QuizletClone.DTOs.Flashcard;
using QuizletClone.DTOs.LearningMode;
using QuizletClone.Helpers;

namespace QuizletClone.DTOs.Course
{
    public class LearningModeDTO
    {
        public int CourseId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Slug { get; set; } = string.Empty;
        public LearningQuestionDTO LearningQuestion { get; set; } = new();
		public int CorrectAnswerCount { get; set; }
		public int CurrentQuestionIndex { get; set; }
        public string CorrectAnswersPerStep { get; set; } = string.Empty;
        public QuestionType QuestionType { get; set; } = QuestionType.Both;
	}
}
