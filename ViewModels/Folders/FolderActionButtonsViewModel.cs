namespace QuizletClone.ViewModels.Folders
{
	public class FolderActionButtonsViewModel
	{
		public int FolderId { get; set; }
		public string BtnState { get; set; } = string.Empty;
		public string BtnTitle { get; set; } = string.Empty;
		public bool IsOwner { get; set; }
		public string OwnerUserId { get; set; } = string.Empty;
		public string OwnerUsername { get; set; } = string.Empty;
	}
}
