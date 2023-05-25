using Application.Repositories.Order;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.Order.GetOrderGroupBy
{
    public class GetOrderGroupByQueryHandler : IRequestHandler<GetOrderGroupByQueryRequest, GetOrderGroupByQueryResponse>
    {
        private readonly IOrderReadRepository _orderReadRepository;

        public GetOrderGroupByQueryHandler(IOrderReadRepository orderReadRepository)
        {
            _orderReadRepository = orderReadRepository;
        }

        public async Task<GetOrderGroupByQueryResponse> Handle(GetOrderGroupByQueryRequest request, CancellationToken cancellationToken)
        {
            List<Domain.Entities.Order> getOrder = 
                await _orderReadRepository.GetWhere(x => x.Date > request.StartDate.ToUniversalTime() && x.Date < request.EndDate.ToUniversalTime()).ToListAsync();
            var getOrderBySegment = getOrder.GroupBy(x =>
            {
                switch (request.ReqGroupType)
                {
                    case "Segment": return x.Segment;
                    case "Country": return x.Country;
                    case "Product": return x.Product;
                    default: return null;

                }
            })
                .Select(g => new SegmentData
            {
                ResGroupType = g.Key,
                ProductCount = g.Count(),
                UnitsSoldSum = g.Sum(x=>x.UnitsSold),
                Discounts = g.Sum(x=>x.Discounts),
                Profit = g.Sum(x=>x.Profit)

            }).ToList();

            var response = new GetOrderGroupByQueryResponse
            {
                SegmentsData = getOrderBySegment
            };

            return await Task.FromResult(response);
        }
    }
}
