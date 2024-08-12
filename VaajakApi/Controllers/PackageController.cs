using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vaajak.Application.Dto.Packages;
using Vaajak.Application.Dto.Primitives;
using Vaajak.Application.Services.Packages;
using Vaajak.Domain.Repositories.Packages;

namespace VaajakApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly IPackageService _packageService;

        public PackageController(IPackageService packageService)
        {
            _packageService = packageService;
        }

        [HttpGet, Route("All")]
        public async Task<IActionResult> GetAll([FromQuery] PaginationRequestDTO paginationRequestDTO)
        {
            var packages = await _packageService.GetAllAsync(paginationRequestDTO);
            return Ok(packages);
        }

        [HttpGet, Route("ById")]
        public async Task<IActionResult> GetById([FromQuery]Guid id, [FromQuery]PaginationRequestDTO paginationRequestDTO)
        {
            var package = await _packageService.GetPackageById(id);
            
            if(package == null)
            {
                return NotFound();
            }
            return Ok(package);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePackage([FromBody] CreatePackageDto createPackageDto)
        {
            try
            {

                var package = await _packageService.CreatePackage(createPackageDto);
            
                if(package == null)
                {
                    return BadRequest();
                }
                return Ok(package);

            }catch(Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }


        }
    }
}
