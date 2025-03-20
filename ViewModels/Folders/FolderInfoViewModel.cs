namespace QuizletClone.ViewModels.Folders
{
	public class FolderInfoViewModel
	{
		public bool IsOwner { get; set; }
		public string OwnerUsername { get; set; } = string.Empty;
		public string UpdatedAt { get; set; } = string.Empty;
		public string CreatedAt { get; set; } = string.Empty;
	}
}
