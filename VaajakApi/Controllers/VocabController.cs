﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vaajak.Application.Dto.Vocabs;
using Vaajak.Application.Services.Vocabs;
using Vaajak.Domain.Repositories.Vocabs;
using Vaajak.Persistence.Contexts;
using VaajakApi.Mappers;

namespace VaajakApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VocabController : ControllerBase
    {
        private readonly IVocabService _vocabService;

        public VocabController(IVocabService vocabService)
        {
            _vocabService = vocabService;
        }

        //private readonly DatabaseContext _context;
        //public VocabController(DatabaseContext context)
        //{
        //    _context = context;
        //}

        [HttpGet, Route("All")]
        public async Task<IActionResult> GetAll() {
            var vocabs = await _vocabService.GetAllVocabs();
                //Vocabs.ToList().Select(s => s.ToVocabsDto());

            return Ok(vocabs);
        }

        //[HttpGet("{id}")]
        //public async IActionResult GetById([FromRoute] string id) {
        //    var vocab = await vocabService.Find(id);

        //    if (vocab == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(vocab.ToVocabsDto());
        //}

        //[HttpPost]
        //public async Task<IActionResult> CreateVocab([FromBody] CreateVocabDto createVocabDto)
        //{
        //    var vocab = createVocabDto.ToVocabEntity();

        //}
    }
}
