using QuizletClone.Helpers;
using QuizletClone.Models;

namespace QuizletClone.Interfaces
{
    public interface IPermissionRepository
    {
        Task<List<Permission>> GetAllAsync(PermissionQueryObject query);
    }
}
