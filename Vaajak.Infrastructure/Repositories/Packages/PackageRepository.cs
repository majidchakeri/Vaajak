using Microsoft.EntityFrameworkCore;
using Vaajak.Domain.Entities;
using Vaajak.Domain.Repositories.Packages;
using Vaajak.Persistence.Contexts;

namespace Vaajak.Infrastructure.Repositories.Packages
{
    public class PackageRepository: IPackagesRepository
    {
        private readonly DatabaseContext _dbContext;

        public PackageRepository(DatabaseContext databaseContext)
        {
            _dbContext = databaseContext;
        }

        public async Task<IEnumerable<Package>> GetAllAsync()
        {
            return await _dbContext.Packages.OrderByDescending(package => package.Id).ToListAsync();
        }

        public async Task<Package> GetPackageById(Guid id)
        {
            try
            {

            var package = await _dbContext.Packages.FirstOrDefaultAsync(x => x.Id == id);
                if(package == null)
                {
                    return null;
                }

                var selectedPackage = new Package
                {
                    Id = id,
                    PackageName = package.PackageName
                };

                return selectedPackage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Package> CreatePackage(Package package)
        {
            if (package == null)
            {
                throw new ArgumentNullException(nameof(package), "package cannot be null");
            }
            try
            {
                var result = await _dbContext.Packages.AddAsync(package);
                await _dbContext.SaveChangesAsync();

                return result.Entity;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
