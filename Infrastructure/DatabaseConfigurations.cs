using Domain.Entities.Identity;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class DatabaseConfigurations
    {
        public static IServiceCollection AddDataBase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MarketPlaceContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
            );

            services.AddDbContextFactory<IdentityContext>(options =>
           options.UseNpgsql(configuration.GetConnectionString("IdentityConnection")));

            services.AddScoped(typeof(ICustomUserIdentityDbInitializer), typeof(CustomUserIdentityDbInitializer));
            return services;
        }
    }
}
