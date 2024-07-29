using System.ComponentModel.DataAnnotations;

namespace Vaajak.Application.Dto.Primitives
{
    public class PaginationRequestDTO
    {
        public int PageNumber { get; set; } = 1;
        [Range(1, 50)] public int PageSize { get; set; } = 10;
        public bool Paging { get; set; } = true;
    }
}
