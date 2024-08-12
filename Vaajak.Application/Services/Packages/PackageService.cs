using Vaajak.Application.Dto.Packages;
using Vaajak.Application.Dto.Primitives;
using Vaajak.Domain.Entities;
using Vaajak.Domain.Repositories.Packages;
using X.PagedList;
using X.PagedList.Extensions;

namespace Vaajak.Application.Services.Packages
{
    public class PackageService: IPackageService
    {
        private readonly IPackagesRepository _packagesRepository;

        public PackageService(IPackagesRepository packagesRepository)
        {
            _packagesRepository = packagesRepository;
        }

        public async Task<IPagedList<PackageDto>> GetAllAsync(PaginationRequestDTO pagination)
        {
            try
            {
                var packages = await _packagesRepository.GetAllAsync();
                var packageDto = packages.Select(Package => new PackageDto
                {
                    Id = Package.Id,
                    PackageName = Package.PackageName
                });

                var paginatedPackages = packageDto.ToPagedList(pagination.PageNumber, pagination.PageSize);

                return paginatedPackages;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<PackageDto?> GetPackageById(Guid id)
        {
            try
            {
                var package = await _packagesRepository.GetPackageById(id);

                if(package == null) return null;


                return new PackageDto
                {
                    Id = package.Id,
                    PackageName = package.PackageName,
                };

            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CreatePackageDto> CreatePackage(CreatePackageDto createPackageDto)
        {
            var package = new Package
            {
                Id = Guid.NewGuid(),
                PackageName = createPackageDto.PackageName,
            };

            var createdPackage = await _packagesRepository.CreatePackage(package);

            var mappedPackage = new CreatePackageDto
            {
                Id = createdPackage.Id,
                PackageName = createdPackage.PackageName,
            };

            return mappedPackage;
        }
    }
}
