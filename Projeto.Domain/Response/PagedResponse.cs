namespace Projeto.Domain.Response
{
    public class PagedResponse<TData>
    {
        public IEnumerable<TData> Data { get; set; } = new List<TData>();
        public int TotalItems { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalItems / PageSize);

        public PagedResponse(IEnumerable<TData> data, int totalItems, int pageNumber, int pageSize)
        {
            Data = data;
            TotalItems = totalItems;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
