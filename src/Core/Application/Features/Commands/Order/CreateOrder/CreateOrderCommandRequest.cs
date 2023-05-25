using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Order.CreateOrder
{
    public class CreateOrderCommandRequest 
        : IRequest<CreateOrderCommandResponse>
    {
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
