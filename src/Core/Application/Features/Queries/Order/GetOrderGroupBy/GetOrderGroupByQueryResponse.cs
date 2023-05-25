using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.Order.GetOrderGroupBy
{
    public class GetOrderGroupByQueryResponse
    {
        public List<SegmentData> SegmentsData { get; set; }
    }
    public class SegmentData
    {
        public string? ResGroupType { get; set; }
        public int?  ProductCount { get; set; }
        public decimal? UnitsSoldSum { get; set; }
        public decimal? Discounts { get; set; }
        public decimal? Profit { get; set; }
    }
}
