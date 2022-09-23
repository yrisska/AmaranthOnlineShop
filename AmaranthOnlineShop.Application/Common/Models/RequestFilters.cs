using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmaranthOnlineShop.Application.Common.Models
{
    public class RequestFilters
    {
        public FilterLogicalOperators LogicalOperator { get; set; }
        public IList<Filter> Filters { get; set; }

    }
}
