using Microsoft.EntityFrameworkCore;
using Vaajak.Application.Interfaces.Context;
using Vaajak.Domain.Entities;

namespace Vaajak.Persistence.Contexts;

public class DatabaseContext:DbContext <User, Role, Guid>, IDatabaseContext
{
    public DbSet<Vocab> Vocabs { get; set; }
    public DbSet<Package> Packages { get; set; }
    public DbSet<Example> Examples { get; set; }
    public DbSet<Translate> Translates { get; set; }
}
