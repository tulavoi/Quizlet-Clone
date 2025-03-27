using System.ComponentModel.DataAnnotations;

namespace QuizletClone.DTOs.Folder
{
	public class AddFolderToLibraryRequestDTO
	{
		[Required]
		[MaxLength(100, ErrorMessage = "Tối đa 50 ký tự")]
		public string Title { get; set; } = string.Empty;
		public string UserId { get; set; } = string.Empty;
		public List<int> CourseIds { get; set; } = new();
	}
}
