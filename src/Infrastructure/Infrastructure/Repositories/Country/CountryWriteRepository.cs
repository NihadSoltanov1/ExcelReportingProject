using Application.Repositories.Country;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Country
{
    public class CountryWriteRepository : WriteRepository<Domain.Entities.Country>, ICountryWriteRepository
    {
        public CountryWriteRepository(ExcelReportingDBContext context) : base(context)
        {
        }
    }
}
