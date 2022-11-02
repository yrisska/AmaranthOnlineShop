using System.Text.Json.Serialization;

namespace AmaranthOnlineShop.Application.Common.Models
{
    public class ProductPagedRequest : PagedRequest
    {
        public override int PageIndex { get; set; } = 1;
        public override int PageSize { get; set; } = 9;
        public override string SortingColumnName { get; set; } = "Id";
        public override string SortDirection { get; set; } = "asc";
        public string? ProductCategory { get; set; }
        public string? Name { get; set; }

        //Internal modifier prevents property from being a query parameter
        internal override RequestFilters? RequestFilters
        {
            get
            {
                var filters = new List<Filter>();

                if (!string.IsNullOrEmpty(Name))
                {
                    filters.Add(new Filter { Path = "Name", Value = Name });
                }

                if (!string.IsNullOrEmpty(ProductCategory))
                {
                    filters.Add(new Filter { Path = "ProductCategory.Name", Value = ProductCategory });
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
