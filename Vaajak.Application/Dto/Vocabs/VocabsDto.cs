using Vaajak.Application.Dto.Packages;

namespace Vaajak.Application.Dto.Vocabs
{
    public class VocabsDto
    {
        public Guid Id { get; set; }
        public string Vocabulary { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Voice { get; set; } = string.Empty;
        public List<PackageDto> Package { get; set;} = new();

    }
}
