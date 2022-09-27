using System.Text.Json.Serialization;

namespace AmaranthOnlineShop.Application.Common.Models
{
    public class ProductPagedRequest
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string SortingColumnName { get; set; }
        public string SortDirection { get; set; }
        public decimal GreaterThan { get; set; }
        public decimal LowerThan { get; set; }
        public string? ProductCategory { get; set; }
        public string? Name { get; set; }

        //Internal modifier prevents property from displaying in swagger
        internal  RequestFilters? RequestFilters
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

                if (GreaterThan > 0)
                {
                    filters.Add(new Filter { Path = "Price", Value = $">{GreaterThan}" });
                }

                if (LowerThan > 0)
                {
                    filters.Add(new Filter { Path = "Price", Value = $"<{LowerThan}" });
                }

                if (filters.Count == 0) return null;

                return new RequestFilters
                {
                    LogicalOperator = 0,
                    Filters = filters
                };
            }
        }
    }
}
