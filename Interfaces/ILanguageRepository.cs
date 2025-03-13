using QuizletClone.Helpers;
using QuizletClone.Models;

namespace QuizletClone.Interfaces
{
    public interface ILanguageRepository
    {
        Task<List<Language>> GetAllAsync(LanguageQueryObject query);
    }
}
