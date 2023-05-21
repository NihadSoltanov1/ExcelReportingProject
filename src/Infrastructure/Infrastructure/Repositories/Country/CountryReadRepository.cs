using Application.Repositories;
using Application.Repositories.Country;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Country
{
    public class CountryReadRepository : ReadRepository<Domain.Entities.Country>, ICountryReadRepository
    {
        public CountryReadRepository(ExcelReportingDBContext context) : base(context)
        {
        }
    }
}
