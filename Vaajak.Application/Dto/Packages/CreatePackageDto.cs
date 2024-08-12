namespace Vaajak.Application.Dto.Packages
{
    public class CreatePackageDto
    {
        public Guid Id { get; set; }
        public string PackageName { get; set; } = string.Empty;

    }
}
