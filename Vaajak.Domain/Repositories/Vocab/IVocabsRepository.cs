using Vaajak.Domain.Entities;

namespace Vaajak.Domain.Repositories.Vocab
{
    public interface IVocabsRepository
    {
        Task<IEnumerable<Vocab>> GetAllAsync();
    }
}
