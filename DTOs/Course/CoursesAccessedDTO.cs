namespace QuizletClone.DTOs.Course
{
    public class CoursesAccessedDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string OwnerUserId { get; set; } = string.Empty;
        public string OwnerUsername { get; set; } = string.Empty;
        public int FlashcardCount { get; set; }
        public bool IsInFolder { get; set; }
    }
}
