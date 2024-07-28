using Vaajak.Domain.Entities;
using Vaajak.Domain.Dto.Vocabs;


namespace Vaajak.Domain.Repositories.Vocabs
{
    public interface IVocabsRepository
    {
        Task<IList<Vocab>> GetAllAsync(int page, int pageSize);
        Task<Vocab?> GetByIdAsync(Guid id);
        // Task<Vocab?> CreateVocab(CreateVocabDto createVocabDto);
        Task<Vocab> CreateVocab(Vocab vocab);
    }
}