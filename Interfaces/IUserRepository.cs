namespace SmartCards.Interfaces
{
    public interface IUserRepository
    {
        Task<string?> GetUserIdAsync(string username);
    }
}
