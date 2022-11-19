namespace AmaranthOnlineShop.Application.Common.Models
{
    public class ProductCategoriesPagedRequest : PagedRequest
    {
        public override int PageIndex { get; set; } = 1;
        public override int PageSize { get; set; } = 9;
        public override string SortingColumnName { get; set; } = "Id";
        public override string SortDirection { get; set; } = "asc";
        public string? Name { get; set; }

        internal override RequestFilters? RequestFilters
        {
            get
            {
                var filters = new List<Filter>();

                if (!string.IsNullOrEmpty(Name))
                {
                    filters.Add(new Filter {Path = "Name", Value = Name});
                }

                return new RequestFilters
                {
                    LogicalOperator = 0,
                    Filters = filters
                };
            }
        }
    }
}