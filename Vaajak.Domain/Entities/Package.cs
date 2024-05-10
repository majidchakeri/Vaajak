namespace Vaajak.Domain.Entities;

public class Package
{
    public Guid Id { get; set; }
    public string PackageName { get; set; } = string.Empty;
    public ICollection<Vocab> Vocabs { get; set; } = new List<Vocab>();
}
