using Vaajak.Domain.Entities;

namespace Vaajak.Application.Services.Vocabs
{
    public interface IVocabService
    {
        Task<IEnumerable<Vocab>> GetAllVocabs();
    }
}