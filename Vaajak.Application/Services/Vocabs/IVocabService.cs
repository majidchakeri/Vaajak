using Vaajak.Application.Dto.Vocabs;
using Vaajak.Domain.Entities;

namespace Vaajak.Application.Services.Vocabs
{
    public interface IVocabService
    {
        Task<IEnumerable<VocabsDto>> GetAllVocabs();
        Task<VocabsDto?> GetById(Guid id);
        Task<CreateVocabDto?> CreateVocab(CreateVocabDto createVocabDto);
    }
}