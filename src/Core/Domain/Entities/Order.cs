﻿using Domain.Common;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order : BaseEntity
    {
        
        public int Id { get; set; }
        public string? Segment { get; set; }
        public string? Country { get; set; }
        public string? Product { get; set; }
        public DiscountBand? DiscountBand { get; set; }
        public decimal? UnitsSold { get; set; }
        public decimal? Manufacturing { get; set; }
        public decimal? SalesPrice { get; set; }
        public decimal? GrossSales { get; set; }
        public decimal? Discounts { get; set; }
        public decimal? Sales { get; set; }
        public decimal? COGS { get; set; }
        public decimal? Profit { get; set; }
        public DateTime? Date { get; set; }

    }
}
