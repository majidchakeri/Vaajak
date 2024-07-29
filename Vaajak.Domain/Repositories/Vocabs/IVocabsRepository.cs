using Vaajak.Domain.Entities;


namespace Vaajak.Domain.Repositories.Vocabs
{
    public interface IVocabsRepository
    {
        Task<IEnumerable<Vocab>> GetAllAsync(Guid packageId);
        Task<Vocab?> GetByIdAsync(Guid id);
        // Task<Vocab?> CreateVocab(CreateVocabDto createVocabDto);
        Task<Vocab?> CreateVocab(Vocab vocab);
    }
}