using Microsoft.EntityFrameworkCore;
using Vaajak.Domain.Entities;
using Vaajak.Domain.Repositories.Vocab;
using Vaajak.Persistence.Contexts;

namespace Vaajak.Infrastructure.Repositories.Vocab
{
    public class VocabRepository(DatabaseContext dbContext) : IVocabsRepository
    {
        public async Task<IEnumerable<Vocab>> GetAllAsync()
        {
            var vocabs = await dbContext.Vocabs.ToListAsync();
            return vocabs;
        }
    }
}
