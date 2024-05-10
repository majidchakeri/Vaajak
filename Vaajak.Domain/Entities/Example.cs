namespace Vaajak.Domain.Entities;

public class Example
{
    public Guid Id { get; set; }
    public string Caseexample { get; set; } = string.Empty;
    public string Exampletran { get; set; } = string.Empty;
    public string Voice { get; set; } = string.Empty;
    public Translate Translate { get; set; }
}
