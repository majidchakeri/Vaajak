using Vaajak.Application.Dto.Packages;
using Vaajak.Application.Dto.Primitives;
using X.PagedList;

namespace Vaajak.Application.Services.Packages
{
    public interface IPackageService
    {
        Task<IPagedList<PackageDto>> GetAllAsync(PaginationRequestDTO pagination);
        Task<PackageDto> GetPackageById(Guid id);
        Task<CreatePackageDto> CreatePackage(CreatePackageDto createPackageDto);
    }
}
