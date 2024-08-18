namespace Vaajak.Application.Dto.Primitives
{
    public class ResponseDTO<T>
    {
        public bool IsSuccess { get; set; }
        public IList<string> Message { get; set; } = [];
        public T Data { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public bool Paging { get; set; }
    }
}
