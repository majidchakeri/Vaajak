namespace Vaajak.Domain.Entities;

internal class Translate
{
    public Guid Id { get; set; }
    public string Vocabtran { get; set; } = string.Empty;
    public string Usage { get; set; } = string.Empty;
    public Guid VocabId { get; set; }
    public Vocab Vocab { get; set; }
}
