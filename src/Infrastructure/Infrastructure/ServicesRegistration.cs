using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Application.Repositories.Country;
using Infrastructure.Repositories.Country;
using Application.Repositories.Order;
using Infrastructure.Repositories.Order;
using Application.Repositories.Product;
using Infrastructure.Repositories.Product;
using Application.Repositories.Segment;
using Infrastructure.Repositories.Segment;

namespace Infrastructure
{
    public static class ServicesRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ExcelReportingDBContext>(option => option.UseNpgsql(configuration.GetConnectionString("PostgreSQL")));

            services.AddScoped<ICountryWriteRepository, CountryWriteRepository>();
            services.AddScoped<ICountryReadRepository, CountryReadRepository>();

            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();

            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();

            services.AddScoped<ISegmentWriteRepository, SegmentWriteRepository>();
            services.AddScoped<ISegmentReadRepository, SegmentReadRepository>();
        }
    }
}
