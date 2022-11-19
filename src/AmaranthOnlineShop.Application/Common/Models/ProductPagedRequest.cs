namespace AmaranthOnlineShop.Application.Common.Models
{
    public class ProductPagedRequest : PagedRequest
    {
        public override int PageIndex { get; set; } = 1;
        public override int PageSize { get; set; } = 9;
        public override string SortingColumnName { get; set; } = "Id";
        public override string SortDirection { get; set; } = "asc";
        public string? ProductCategory { get; set; }
        public int? ProductCategoryId { get; set; }
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

                if (ProductCategoryId.HasValue)
                {
                    filters.Add(new Filter {Path = "ProductCategoryId", Value = ProductCategoryId.Value.ToString()});
                }
                else if (!string.IsNullOrEmpty(ProductCategory))
                {
                    filters.Add(new Filter {Path = "ProductCategory.Name", Value = ProductCategory});
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