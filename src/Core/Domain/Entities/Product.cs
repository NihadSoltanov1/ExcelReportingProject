using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product : BaseEntity
    {
        public string? Name { get; set; }
        public decimal ManufacturingPrice { get; set; }
        public decimal SalePrice { get; set; }
    }
}
