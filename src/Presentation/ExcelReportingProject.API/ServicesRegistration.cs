using Application.Repositories.Order;
using Application.Services;
using Infrastructure.Context;
using Infrastructure.Repositories.Order;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace ExcelReportingProject.API
{
    public static class ServicesRegistration
    {
        public static void AddPresentationServices(this IServiceCollection services)
        {
            services.AddScoped<IFileUploadService, FileUploadService>();
            services.AddScoped<ISendMailService, SendMailService>();
            services.AddScoped<IFileUploadService, FileUploadService>();
        }
    }
}
