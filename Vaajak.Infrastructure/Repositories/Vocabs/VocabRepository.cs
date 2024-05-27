using Microsoft.EntityFrameworkCore;
using Vaajak.Domain.Entities;
using Vaajak.Domain.Repositories.Vocabs;
using Vaajak.Persistence.Contexts;

namespace Vaajak.Infrastructure.Repositories.Vocabs
{
    public class VocabRepository(DatabaseContext dbContext) : IVocabsRepository
    {
        public async Task<IEnumerable<Vocab>> GetAllAsync()
        {
            var vocabs = await dbContext.Vocabs.ToListAsync();
            return vocabs;
        }

        public async Task<Vocab?> GetByIdAsync(Guid id)
        {
            var vocab = await dbContext.Vocabs.FirstOrDefaultAsync(x => x.Id == id);
            return vocab;
        }
    }
}
