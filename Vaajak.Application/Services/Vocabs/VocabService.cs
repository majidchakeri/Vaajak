﻿using Vaajak.Application.Dto.Primitives;
using Vaajak.Application.Dto.Vocabs;
using Vaajak.Domain.Entities;
using Vaajak.Domain.Repositories.Vocabs;
using X.PagedList;
using X.PagedList.Extensions;

namespace Vaajak.Application.Services.Vocabs
{
    internal class VocabService : IVocabService
    {
        private readonly IVocabsRepository _vocabsRepository;
        
        public VocabService(IVocabsRepository vocabsRepository)
        {
            _vocabsRepository = vocabsRepository;
        }
        
        public async Task<IPagedList<VocabsDto>> GetAllAsync(Guid packageId, PaginationRequestDTO pagination)
        {
            var vocabs = await _vocabsRepository.GetAllAsync();
            var vocabsDto = vocabs.Select(vocab => new VocabsDto
            {
                Id = vocab.Id,
                Vocabulary = vocab.Vocabulary,
                Type = vocab.Type,
                Voice = vocab.Voice
            });
            var paginatedVocabs = vocabsDto.ToPagedList(pagination.PageNumber, pagination.PageSize);

            return paginatedVocabs;
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

        public async Task<CreateVocabDto> CreateVocab(CreateVocabDto createVocabDto)
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

            var vocabDto = new CreateVocabDto
            {
                Vocabulary = createdVocab.Vocabulary,
                Type = createdVocab.Type,
                Voice = createdVocab.Voice
                // Add additional properties here if needed
            };

            return vocabDto;
        }

       
    }
}
