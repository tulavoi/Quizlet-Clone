using SmartCards.Models;

namespace SmartCards.Interfaces
{
    public interface IFolderRepository
    {
        Task<Folder> CreateAsync(Folder folder);
        Task<Folder?> GetByIdAsync(int id);
    }
}
