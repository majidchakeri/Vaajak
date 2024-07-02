using Vaajak.Application.Dto.Vocabs;
using Vaajak.Domain.Entities;
using Vaajak.Domain.Repositories.Vocabs;

namespace Vaajak.Application.Services.Vocabs
{
    internal class VocabService(IVocabsRepository vocabsRepository) : IVocabService
    {
        public async Task<IEnumerable<VocabsDto>> GetAllVocabs()
        {
            var vocabs = await vocabsRepository.GetAllAsync();
            if (!vocabs) return BadRequest();

            return vocabs;
        }

        public async Task<VocabsDto?> GetById(Guid id)
        {
            var vocab = await vocabsRepository.GetByIdAsync(id);
            return vocab;
        }

        public async Task<CreateVocabDto> CreateVocab(CreateVocabDto createVocabDto)
        {
            var vocab = await vocabsRepository.CreateVocab
        }
    }
}
