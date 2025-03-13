namespace QuizletClone.Interfaces
{
    public interface IUserRepository
    {
        Task<string?> GetUserIdAsync(string username);
    }
}
