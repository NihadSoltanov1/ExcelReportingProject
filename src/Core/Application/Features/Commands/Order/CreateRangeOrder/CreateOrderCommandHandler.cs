using Application.Repositories.Order;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Order.CreateRangeOrder
{
    public class CreateRangeOrderCommandHandler : IRequestHandler<CreateRangeOrderCommandRequest, CreateRangeOrderCommandResponse>
    {
        private readonly IOrderWriteRepository _orderWriteRepository;

        public CreateRangeOrderCommandHandler(IOrderWriteRepository orderWriteRepository)
        {
            _orderWriteRepository = orderWriteRepository;
        }

        public async Task<CreateRangeOrderCommandResponse> Handle(CreateRangeOrderCommandRequest request, CancellationToken cancellationToken)
        {
               await  _orderWriteRepository.AddAsync(
                new Domain.Entities.Order()
                {
                    Segment = request.Segment,
                    Country = request.Country,
                    Product = request.Product,
                    DiscountBand = request.DiscountBand,
                    UnitsSold = request.UnitsSold,
                    Manufacturing = request.Manufacturing,
                    SalesPrice = request.SalesPrice,
                    GrossSales = request.GrossSales,
                    Discounts = request.Discounts,
                    Sales = request.Sales,
                    COGS = request.COGS,
                    Profit = request.Profit,
                    Date = request.Date
                }
                );
            return new CreateRangeOrderCommandResponse();
        }
    }
}
