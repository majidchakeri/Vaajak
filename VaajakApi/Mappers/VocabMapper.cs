using Humanizer.Inflections;
using Vaajak.Application.Dto.Vocab;
using Vaajak.Domain.Entities;

namespace VaajakApi.Mappers
{
    public static class VocabMapper
    {
        public static VocabsDto ToVocabsDto(this Vocab Vocab)
        {
            return new VocabsDto
            {
                Id = Vocab.Id,
                Vocabulary = Vocab.Vocabulary,
                Type = Vocab.Type,
                Voice = Vocab.Voice,
            };
        }

        public static CreateVocabDto ToCreateVocabsDto(this Vocab VocabsDto)
        {
            return new CreateVocabDto
            {
                Vocabulary = VocabsDto.Vocabulary,
                Type = VocabsDto.Type,
                Voice = VocabsDto.Voice,
            };
        }
    }
}
