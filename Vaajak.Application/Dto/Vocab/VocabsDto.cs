namespace Vaajak.Application.Dto.Vocab
{
    public class VocabsDto
    {
        public Guid Id { get; set; }
        public string Vocabulary { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Voice { get; set; } = string.Empty;

    }
}
