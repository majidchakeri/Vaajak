﻿using Vaajak.Application.Dto.Vocabs;
using Vaajak.Domain.Entities;
using Vaajak.Domain.Repositories.Vocabs;

namespace Vaajak.Application.Services.Vocabs
{
    internal class VocabService : IVocabService
    {
        private readonly IVocabsRepository _vocabsRepository;
        
        public VocabService(IVocabsRepository vocabsRepository)
        {
            _vocabsRepository = vocabsRepository;
        }
        
        public async Task<IEnumerable<VocabsDto>> GetAllVocabs()
        {
            var vocabs = await _vocabsRepository.GetAllAsync();
            return vocabs.Select(v => new VocabsDto
            {
                Id = v.Id,
                Vocabulary = v.Vocabulary,
                Type = v.Type,
                Voice = v.Voice
            });
        }
        
        public async Task<VocabsDto?> GetById(Guid id)
        {
            var vocab = await _vocabsRepository.GetByIdAsync(id);
            if (vocab == null) return null;
            return new VocabsDto
            {
                Id = vocab.Id,
                Vocabulary = vocab.Vocabulary,
                Type = vocab.Type,
                Voice = vocab.Voice
                // سایر خواص را اینجا اضافه کنید
            };
        }

        public async Task<VocabsDto> CreateVocab(CreateVocabDto createVocabDto)
        {
            var vocab = new Vocab
            {
                Id = Guid.NewGuid(),
                Vocabulary = createVocabDto.Vocabulary,
                Type = createVocabDto.Type,
                Voice = createVocabDto.Voice
                // سایر خواص را اینجا اضافه کنید
            };
            var createdVocab = await _vocabsRepository.CreateVocab(vocab);
            return new VocabsDto
            {
                Id = createdVocab.Id,
                Vocabulary = createdVocab.Vocabulary,
                Type = createdVocab.Type,
                Voice = createdVocab.Voice
                // سایر خواص را اینجا اضافه کنید
            };
        }

       
    }
}