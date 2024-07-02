using Microsoft.EntityFrameworkCore;
using Vaajak.Application.Dto.Vocabs;
using Vaajak.Domain.Entities;
using Vaajak.Domain.Repositories.Vocabs;
using Vaajak.Persistence.Contexts;

namespace Vaajak.Infrastructure.Repositories.Vocabs
{
    public class VocabRepository(DatabaseContext dbContext) : IVocabsRepository
    {
        public async Task<IEnumerable<VocabsDto>> GetAllAsync()
        {
            var vocabs = await dbContext.Vocabs.ToListAsync();
            return vocabs;
        }

        public async Task<VocabsDto> GetByIdAsync(Guid id)
        {
            var vocab = await dbContext.Vocabs.FirstOrDefaultAsync(x => x.Id == id);
            return vocab;
        }
        public async Task<CreateVocabDto> CreateVocab(CreateVocabDto createVocabDto)
        {
            var vocab = await dbContext.AddAsync(createVocabDto);

            await dbContext.SaveChangesAsync();

            if (vocab != null)
            {
                throw new InvalidOperationException("Failed to create vocabulary");
            }
            return createVocabDto;
        }
    }
}
