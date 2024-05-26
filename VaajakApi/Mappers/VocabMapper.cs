using Humanizer.Inflections;
using Vaajak.Application.Dto.Vocabs;
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

        public static CreateVocabDto ToCreateVocabsDto(this CreateVocabDto createVocabDto)
        {
            return new CreateVocabDto
            {
                Vocabulary = createVocabDto.Vocabulary,
                Type = createVocabDto.Type,
                Voice = createVocabDto.Voice,
                //Translations = createVocabDto.Translations.Select(t => new Translate { Vocabtran = t }).ToList(),
            };
        }
    }
}
