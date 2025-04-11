// API/Extensions/ServiceExtensions.cs
using BiddingManagementSystem.Domain.Contracts;
using BiddingManagementSystem.Infrastructure.Authentication;
using BiddingManagementSystem.Infrastructure.Persistence;
using BiddingManagementSystem.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BiddingManagementSystem.API.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddProjectServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>)); 
            services.AddScoped<ITenderRepository, TenderRepository>();
            services.AddScoped<IBidRepository, BidRepository>();
            services.AddScoped<JwtService>();

            return services;
        }
    }
}
