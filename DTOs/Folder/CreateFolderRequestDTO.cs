using QuizletClone.DTOs.Flashcard;
using System.ComponentModel.DataAnnotations;

namespace QuizletClone.DTOs.Folder
{
    public class CreateFolderRequestDTO
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Tối đa 50 ký tự")]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string UserId { get; set; } = string.Empty;
    }
}
