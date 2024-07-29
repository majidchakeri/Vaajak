using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Vaajak.Application.Dto.Primitives;
using Vaajak.Application.Dto.Vocabs;
using Vaajak.Domain.Entities;
using Vaajak.Domain.Repositories.Vocabs;
using Vaajak.Persistence.Contexts;
using X.PagedList;
using X.PagedList.Extensions;

namespace Vaajak.Infrastructure.Repositories.Vocabs
{
    public class VocabRepository : IVocabsRepository
    {
        private readonly DatabaseContext _dbContext;
        public VocabRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Vocab>> GetAllAsync(Guid packageId)
        {
            // Ensure the query is correctly constructed
            return await _dbContext.Vocabs
                .OrderByDescending(vocab => vocab.Id)
                .ToListAsync();

        }

        public async Task<Vocab?> GetByIdAsync(Guid id)
        {
            try
            {

            var vocab = await _dbContext.Vocabs.FirstOrDefaultAsync(x => x.Id == id);
            if (vocab == null)
            {
                    return null;
            }
                var vocabDto = new Vocab
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

        public async Task<Vocab> CreateVocab(Vocab vocab)
        {
            if (vocab == null)
            {
                throw new ArgumentNullException(nameof(vocab), "CreateVocabDto cannot be null");
            }

            try
            {
                if (vocab.Package != null)
                {
                    foreach (var package in vocab.Package)
                    {
                        if (_dbContext.Entry(package).State == EntityState.Detached)
                        {
                            _dbContext.Attach(package);
                        }
                    }
                }

                if (vocab.Translations != null)
                {
                    foreach (var translation in vocab.Translations)
                    {
                        if (_dbContext.Entry(translation).State == EntityState.Detached)
                        {
                            _dbContext.Attach(translation);
                        }
                    }
                }

                // Add the new Vocab entity to the context
                var result = await _dbContext.Vocabs.AddAsync(vocab);

                // Save changes to the database
                await _dbContext.SaveChangesAsync();

                // Return the newly created Vocab entity with its ID populated
                return result.Entity;
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
