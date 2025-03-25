namespace QuizletClone.ViewModels.Folders
{
	public class CourseFolderViewModel
	{
		public int FolderId { get; set; }
		public bool IsOwner { get; set; }
		public bool HasPublicCourses { get; set; }
		public List<CourseInFolderViewModel>? Courses { get; set; } = new();
	}
}
