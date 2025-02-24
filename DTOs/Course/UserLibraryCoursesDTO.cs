using SmartCards.Models;

namespace SmartCards.DTOs.Course
{
    public class UserLibraryCoursesDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Slug { get; set; } = string.Empty;
        public string OwnerUserId { get; set; } = string.Empty;
        public string OwnerUsername { get; set; } = string.Empty;
        public int FlashcardCount { get; set; }
        public PermissionType? ViewPermissionType { get; set; }
    }
}
