using Microsoft.AspNetCore.Identity;
using Vaajak.Domain.Entities;
using Vaajak.Domain.Repositories.Account;

namespace Vaajak.Persistence.Repositories.Account
{
    public class AccountRepository: IAccountRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AccountRepository(UserManager<User> userManager, SignInManager<User> signInManager, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<User?> SignUpAsync(User user)
        {
            
        }
    }
}
