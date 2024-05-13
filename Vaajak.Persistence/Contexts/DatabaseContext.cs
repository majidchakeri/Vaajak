using Microsoft.EntityFrameworkCore;
using Vaajak.Application.Interfaces.Context;
using Vaajak.Domain.Entities;

namespace Vaajak.Persistence.Contexts;

public class DatabaseContext: DbContext, IDatabaseContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> dbContextOptions) : base(dbContextOptions)
    {
        
    }
    
    public DbSet<Vocab> Vocabs { get; set; }
    public DbSet<Package> Packages { get; set; }
    public DbSet<Example> Examples { get; set; }
    public DbSet<Translate> Translates { get; set; }
}
