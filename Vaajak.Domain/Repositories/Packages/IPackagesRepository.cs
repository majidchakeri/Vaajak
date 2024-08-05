using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vaajak.Domain.Entities;

namespace Vaajak.Domain.Repositories.Packages
{
    public interface IPackagesRepository
    {
        Task<IEnumerable<Package>> GetAllAsync();
        Task<Package> GetPackageById(Guid id);
        Task<Package> CreatePackage(Package package);
    }
}
