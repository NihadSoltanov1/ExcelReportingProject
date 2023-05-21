using Application.Repositories.Segment;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Segment
{
    public class SegmentReadRepository : ReadRepository<Domain.Entities.Segment>, ISegmentReadRepository
    {
        public SegmentReadRepository(ExcelReportingDBContext context) : base(context)
        {
        }
    }
}
