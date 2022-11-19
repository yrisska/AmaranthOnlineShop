namespace AmaranthOnlineShop.Application.Common.Models
{
    public class PaginatedResult<T> where T : class
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Total { get; set; }
        public int TotalPages => (int) Math.Ceiling(Total / (double) PageSize);
        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;
        public IList<T> Items { get; set; }
    }
}