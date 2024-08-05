using Vaajak.Domain.Entities;

namespace Vaajak.Application.Dto.Packages
{
    public class PackageDto
    {
        public Guid Id { get; set; }
        public string PackageName { get; set; } = string.Empty;
    }
}
