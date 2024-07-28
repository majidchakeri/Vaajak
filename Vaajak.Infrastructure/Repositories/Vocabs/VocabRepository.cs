using Microsoft.EntityFrameworkCore;
using Vaajak.Application.Dto.Primitives;
using Vaajak.Application.Dto.Vocabs;
using Vaajak.Domain.Entities;
using Vaajak.Domain.Repositories.Vocabs;
using Vaajak.Persistence.Contexts;
using X.PagedList;

namespace Vaajak.Infrastructure.Repositories.Vocabs
{
    public class VocabRepository : IVocabsRepository
    {
        private readonly DatabaseContext _dbContext;
        public VocabRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<VocabsDto>> GetAllAsync(Guid packageId ,PaginationRequestDTO pagination)
        {
            var query = _dbContext.Vocabs.Where(vocab => vocab.Package.Any(package => package.Id == packageId)).AsQueryable();

            if (pagination.Paging)
            {
                var paginatedVocabs = await query.Select(vocab => new VocabsDto
                {
                    Id = vocab.Id,
                    Vocabulary = vocab.Vocabulary,
                    Type = vocab.Type,
                    Voice = vocab.Voice,
                }).ToPagedListAsync(pagination.Page, pagination.PageSize);
                    
            }
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
