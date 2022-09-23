﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmaranthOnlineShop.Application.Common.Models
{
    public class PagedRequest
    {
        public PagedRequest(RequestFilters requestFilters)
        {
            RequestFilters = requestFilters;
        }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string SortingColumnName { get; set; }
        public string SortDirection { get; set; }
        public RequestFilters RequestFilters { get; set; }
    }

}