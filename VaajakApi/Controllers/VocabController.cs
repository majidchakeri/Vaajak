using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vaajak.Persistence.Contexts;

namespace VaajakApi.Controllers
{
    [Route("api/vocab")]
    [ApiController]
    public class VocabController : ControllerBase
    {
        private readonly DatabaseContext _context;
        public VocabController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll() {
            var vocabs = _context.Vocabs.ToListAsync();

            return Ok(vocabs);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromQuery] int id) {
            var vocab = _context.Vocabs.Find(id);

            if (vocab == null)
            {
                return NotFound();
            }

            return Ok(vocab);
        }

        //[HttpPost]
    }
}
