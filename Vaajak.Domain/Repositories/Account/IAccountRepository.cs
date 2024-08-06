using Vaajak.Domain.Entities;

namespace Vaajak.Domain.Repositories.Account
{
    public interface IAccountRepository
    {
        Task<User> SignUpAsync(User user, string password);
        Task<User> SignIpAsync(string username, string password);
        Task<User> FindByEmailAsync(string email);
        Task<bool> CheckPasswordAsync(User user, string password);
        Task<string> GenerateJwtTokenAsync(User user);
    }
}
