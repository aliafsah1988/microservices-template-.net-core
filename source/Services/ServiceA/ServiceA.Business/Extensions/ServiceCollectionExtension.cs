using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceA.Data;
using ServiceA.Business.Mappers;
using ServiceA.Business.Services;
using ServiceA.Business.Services.Interface;
using ServiceA.Data.Interface;
using ServiceA.Data.Repositories;

namespace ServiceA.Business.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddABusiness(this IServiceCollection services, IConfiguration configuration)
        {
            // Service
            services.AddScoped<ISomeService, SomeService>();

            // Repository
            services.AddScoped<ISomeRepository, SomeRepository>();

            // Mappers
            services.AddAutoMapper(x => x.AddProfile(new MappingProfile()));

            // Connection String
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlServerConnection")));

            return services;
        }
    }
}
