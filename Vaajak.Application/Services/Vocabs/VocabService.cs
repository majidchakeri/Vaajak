using Vaajak.Domain.Entities;
using Vaajak.Domain.Repositories.Vocabs;

namespace Vaajak.Application.Services.Vocabs
{
    internal class VocabService(IVocabsRepository vocabsRepository) : IVocabService
    {
        public async Task<IEnumerable<Vocab>> GetAllVocabs()
        {
            var vocabs = await vocabsRepository.GetAllAsync();
            return vocabs;
        }
    }
}
