using Application.Features.Queries.Order.GetOrderGroupBy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface ISendMailService
    {
        public Task SendMail(List<SegmentData> segment);
    }
}
