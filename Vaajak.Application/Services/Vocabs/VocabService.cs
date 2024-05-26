using Vaajak.Domain.Entities;
using Vaajak.Domain.Repositories.Vocabs;

namespace Vaajak.Application.Services.Vocabs
{
    public class VocabService(IVocabsRepository vocabsRepository)
    {
        public async Task<IEnumerable<Vocab>> GetAllVocabs()
        {
             var vocabs = await vocabsRepository.GetAllAsync();
            return vocabs;
        }
    }
}
