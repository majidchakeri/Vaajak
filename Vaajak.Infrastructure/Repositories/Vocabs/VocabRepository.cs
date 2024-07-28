using Microsoft.AspNetCore.Http.HttpResults;
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
            try
            {

            var vocab = await _dbContext.Vocabs.FirstOrDefaultAsync(x => x.Id == id);
            if (vocab == null)
            {
                    return null;
            }
                var vocabDto = new VocabsDto
                {
                    Id = vocab.Id,
                    Vocabulary = vocab.Vocabulary,
                    Type = vocab.Type,
                    Voice = vocab.Voice,
                };

            return vocabDto;
            }
            catch (Exception ex)
            {
                // Log the exception (using a logging framework of your choice)
                Console.WriteLine($"Error fetching vocab by id: {ex.Message}");
                // Handle or rethrow the exception as needed
                throw;
            }
        }

        public async Task<CreateVocabDto> CreateVocab(CreateVocabDto createVocabDto)
        {
            if (createVocabDto == null)
            {
                throw new ArgumentNullException(nameof(createVocabDto), "CreateVocabDto cannot be null");
            }

            try
            {
                var vocabEntity = new Vocab
                {
                    Vocabulary = createVocabDto.Vocabulary,
                    Type = createVocabDto.Type,
                    Voice = createVocabDto.Voice,
                };

                var vocab = await _dbContext.AddAsync(vocabEntity);

                await _dbContext.SaveChangesAsync();

                var createdVocabDto = new CreateVocabDto
                {
                    Vocabulary = createVocabDto.Vocabulary,
                    Type = createVocabDto.Type,
                    Voice = createVocabDto.Voice,
                    PackageId = createVocabDto.PackageId,
                    Translations = createVocabDto.Translations,
                };


                return createVocabDto;
            }
            catch (Exception ex)
            {
                // Log exception and rethrow
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }
    }
}
