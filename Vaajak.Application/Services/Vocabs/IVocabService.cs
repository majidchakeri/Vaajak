using Vaajak.Domain.Entities;

namespace Vaajak.Application.Services.Vocabs
{
    public interface IVocabService
    {
        Task<IEnumerable<Vocab>> GetAllVocabs();
        Task<Vocab?> GetById(Guid id);
    }
}