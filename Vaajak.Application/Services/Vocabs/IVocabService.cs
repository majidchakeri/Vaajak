using Vaajak.Application.Dto.Primitives;
using Vaajak.Application.Dto.Vocabs;
using Vaajak.Domain.Entities;

namespace Vaajak.Application.Services.Vocabs
{
    public interface IVocabService
    {
        Task<IEnumerable<VocabsDto>> GetAllVocabs(PaginationRequestDTO pagination);
        Task<VocabsDto?> GetById(Guid id);
    }
}