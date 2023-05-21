using Application.Repositories.Segment;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Segment
{
    public class SegmentWriteRepository : WriteRepository<Domain.Entities.Segment>, ISegmentWriteRepository
    {
        public SegmentWriteRepository(ExcelReportingDBContext context) : base(context)
        {
        }
    }
}
