using Vaajak.Application.Dto.Account;
using Vaajak.Application.Dto.Primitives;
using X.PagedList;

namespace Vaajak.Application.Services.Account
{
    public class AccountService : IAccountService
    {
        private readonly IAccountService _accountService;
        public AccountService(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<IPagedList<AccountDto>> GetAllAsync(PaginationRequestDTO paginationRequestDTO)
        {
            var accounts = _accountService.GetAllAsync(paginationRequestDTO);

        }
    }
}
