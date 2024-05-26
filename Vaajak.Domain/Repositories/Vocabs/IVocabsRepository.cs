using Vaajak.Domain.Entities;

namespace Vaajak.Domain.Repositories.Vocabs
{
    public interface IVocabsRepository
    {
        Task<IEnumerable<Vocab>> GetAllAsync();
    }
}
