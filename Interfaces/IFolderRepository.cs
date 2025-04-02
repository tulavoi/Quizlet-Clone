using QuizletClone.DTOs.Folder;
using QuizletClone.Helpers;
using QuizletClone.Models;

namespace QuizletClone.Interfaces
{
    public interface IFolderRepository
    {
        Task<Folder> CreateAsync(Folder folder);
        Task UpdateAsync(int id, UpdateFolderRequestDTO folderDTO);
        Task<Folder?> DeleteAsync(int id);
        Task<Folder?> GetByIdAsync(int id);
        Task<List<Folder>?> GetAllAsync(string userId, FolderQueryObject queryObject);
        Task<List<CourseFolder>?> GetCourseInFolderAsync(int folderId);
        Task<List<Folder>?> GetFoldersContainingCourseAsync(int folderId, string userId);
        Task<Folder> AddToLibrary(Folder folder);
	}
}
