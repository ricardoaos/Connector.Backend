using BasicCrud.Infra.SqlServer.Context;
using Connector.Backend.Domain;
using Connector.Backend.Domain.Configurations;
using Connector.Backend.Infra.Context;
using Connector.Backend.Infra.SqlServer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace Connector.Backend.Infra.SqlServer
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSqlServerDependency(this IServiceCollection services)
        {
            services
                .AddInfraDependency()
                .AddTnfDbContext<CrudDbContext, SqlServerCrudDbContext>((config) =>
                {
                    if (Connector.Backend.Domain.Constants.IsDevelopment())
                    {
                        config.DbContextOptions.EnableSensitiveDataLogging();
                        config.UseLoggerFactory();
                    }

                    if (config.ExistingConnection != null)
                        config.DbContextOptions.UseSqlServer(config.ExistingConnection);
                    else
                        config.DbContextOptions.UseSqlServer(config.ConnectionString);
                });

            return services;
        }
    }
}
