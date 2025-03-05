using SmartCards.Helpers;
using SmartCards.Models;

namespace SmartCards.Interfaces
{
    public interface IFolderRepository
    {
        Task<Folder> CreateAsync(Folder folder);
        Task<Folder?> GetByIdAsync(int id);
        Task<List<Folder>?> GetAllAsync(string userId, FolderQueryObject queryObject);
    }
}
