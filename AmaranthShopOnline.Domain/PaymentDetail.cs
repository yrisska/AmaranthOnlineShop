﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmaranthShopOnline.Domain
{
    public class PaymentDetail : BaseEntity
    {
        public decimal Amount { get; set; }
        public string Provider { get; set; }
        public string Status { get; set; }
        public int OrderDetailId { get; set; }
        public OrderDetail OrderDetail { get; set; }
    }
}
