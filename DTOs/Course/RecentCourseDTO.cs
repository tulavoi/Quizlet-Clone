namespace QuizletClone.DTOs.Course
{
    public class RecentCourseDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Slug { get; set; } = string.Empty;
        public string OwnerUserId { get; set; } = string.Empty;
        public string OwnerUsername { get; set; } = string.Empty;
        public string? Password { get; set; } = string.Empty;
        public string RelativeTime { get; set; } = string.Empty;
        public int FlashcardCount { get; set; }
    }
}
