using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vaajak.Domain.Entities;

namespace Vaajak.Infrastructure.IdentityConfig
{
    public static class IdentityConfig
    {

        public static IServiceCollection AddIdentityService(this IServiceCollection services, IConfiguration configuration)
        {

            var connectionString = configuration.GetConnectionString("SqlServer");

            services.AddDbContext<IdentityDatabaseContext>(options =>options.UseSqlServer(connectionString));

            services.AddIdentityCore<User, Role>()
               .AddEntityFrameworkStores<IdentityDatabaseContext>()
               .AddDefaultTokenProviders();
            //services.AddIdentity
            return services;

        }
    }
}

