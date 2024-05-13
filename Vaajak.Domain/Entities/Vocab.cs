namespace Vaajak.Domain.Entities;

public class Vocab
{
    public Guid Id { get; set; }
    public string Vocabulary { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Voice { get; set; } = string.Empty;
    public ICollection<Package> Package { get; set; } = new List<Package>();
    public ICollection<Translate> Translations { get; set; } = new List<Translate>();
}
