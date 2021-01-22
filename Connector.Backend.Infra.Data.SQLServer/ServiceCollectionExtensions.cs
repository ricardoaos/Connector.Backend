using Microsoft.Extensions.DependencyInjection;
using System;
using Connector.Backend.Domain;
using BasicCrud.Infra.Context;
using BasicCrud.Infra.SqlServer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace Connector.Backend.Infra.Data.SQLServer
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSQLServerDependency(this IServiceCollection services)
        {
            services
                .AddInfraDependency()
                .AddTnfDbContext<ConnectorDbContext, SQLServerCrudDbContext>((config) =>
                {
                    if (Constants.IsDevelopment())
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