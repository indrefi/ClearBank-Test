using ClearBank.Application.Common.Constants;
using ClearBank.Application.Extensions;
using ClearBank.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ClearBank.Persistance.Extensions
{
    public static class PersistenceDependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddDBContext(configuration);

            return services;
        }

        public static IServiceCollection AddDBContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ClearBankDbContext>(options =>
            {
                var connectionStringSelector = configuration.GetDataStorageTypeConfigurationOrDefault();
                var connectionString = connectionStringSelector.Equals(ConfigrationConstants.BackUp) ?
                    configuration.GetConnectionString("ClearBankBackUp") :
                    configuration.GetConnectionString("ClearBank");
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<IClearBankDbContext>(provider => provider.GetRequiredService<ClearBankDbContext>());

            return services;
        }
    }

}
