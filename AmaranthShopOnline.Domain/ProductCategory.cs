using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmaranthShopOnline.Domain
{
    public class ProductCategory : BaseEntity
    {
        public string Name { get; set; }
        public ICollection Products { get; set; }
    }
}
