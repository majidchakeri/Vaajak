using Vaajak.Application.Dto.Account;
using Vaajak.Application.Dto.Primitives;
using X.PagedList;

namespace Vaajak.Application.Services.Account
{
    public interface IAccountService
    {
        Task<IPagedList<AccountDto>> GetAllAsync(PaginationRequestDTO paginationRequestDTO);
        Task
    }
}