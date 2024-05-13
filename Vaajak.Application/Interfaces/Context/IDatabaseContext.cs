using Microsoft.EntityFrameworkCore;
using Vaajak.Domain.Entities;

namespace Vaajak.Application.Interfaces.Context
{
    public interface IDatabaseContext
    {
        DbSet<Vocab> Vocabs { get; set; }
        DbSet<Package> Packages { get; set; }
        DbSet<Example> Examples { get; set; }
        DbSet<Translate> Translates { get; set; }

        int SaveChanges();
        int SaveChanges(bool acceptAllChangesOnSuccess);
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
