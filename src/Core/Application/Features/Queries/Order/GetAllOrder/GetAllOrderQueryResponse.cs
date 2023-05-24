using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.Order.GetAllOrder
{
    public class GetAllOrderQueryResponse
    {
        public int SegmentId { get; set; }
        public int CountryId { get; set; }
        public int ProductId { get; set; }
        public DiscountBand DiscountBand { get; set; }


        public decimal UnitsSold { get; set; }
        public decimal GrossSales { get; set; }
        public decimal Sales { get; set; }
        public decimal Discounts { get; set; }
        public decimal Profit { get; set; }
        public decimal COGS { get; set; }
        public DateTime Date { get; set; }
    }
}
