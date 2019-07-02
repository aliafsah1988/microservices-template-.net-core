using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceA.Business.Data;
using ServiceA.Business.Data.Interface;
using ServiceA.Business.Data.Repositories;
using ServiceA.Business.Mappers;
using ServiceA.Business.Services;
using ServiceA.Business.Services.Interface;

namespace ServiceA.Business.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddABusiness(this IServiceCollection services, IConfiguration configuration)
        {
            // Service
            services.AddScoped<IAService, AService>();

            // Repository
            services.AddScoped<IARepository, ARepository>();

            // Mappers
            services.AddAutoMapper(x => x.AddProfile(new MappingProfile()));

            // Connection String
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlServerConnection")));

            return services;
        }
    }
}
