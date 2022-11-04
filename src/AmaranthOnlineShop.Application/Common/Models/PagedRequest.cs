namespace AmaranthOnlineShop.Application.Common.Models
{
    // Should be interface?
    public abstract class PagedRequest 
    {
        public abstract int PageIndex { get; set; }
        public abstract int PageSize { get; set; }
        public abstract string SortingColumnName { get; set; }
        public abstract string SortDirection { get; set; }
        internal abstract RequestFilters? RequestFilters { get; }
    }

}
