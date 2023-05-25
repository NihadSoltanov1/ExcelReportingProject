using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.Order.GetOrderGroupBy
{
    public class GetOrderGroupByQueryRequest : IRequest<GetOrderGroupByQueryResponse>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ReqGroupType { get; set; }
    }
}
