using AmaranthOnlineShop.Domain;
using System.Text.Json.Serialization;

namespace AmaranthOnlineShop.Application.Common.Models
{
    public class OrdersPagedRequest : PagedRequest
    {
        public override int PageIndex { get; set; } = 1;
        public override int PageSize { get; set; } = 9;
        public override string SortingColumnName { get; set; } = "Id";
        public override string SortDirection { get; set; } = "asc";
        public OrderStatus? Status { get; set; }
        [JsonIgnore] public string? UserId { get; set; }

        internal override RequestFilters? RequestFilters
        {
            get
            {
                var filters = new List<Filter>();

                if (!string.IsNullOrEmpty(UserId))
                {
                    filters.Add(new Filter {Path = "UserId", Value = UserId});
                }

                if (Status.HasValue)
                {
                    filters.Add(new Filter {Path = "Status", Value = Status.Value.ToString()});
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