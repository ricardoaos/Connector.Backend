using System.Threading;
using System.Threading.Tasks;
using Connector.Backend.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Tnf;
using Tnf.Configuration;

namespace Connector.Backend.Web.HostedServices
{
    public class MigrationHostedService : IHostedService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public MigrationHostedService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = _serviceScopeFactory.CreateScope();

            var crudDbContext = scope.ServiceProvider.GetService<CrudDbContext>();
            await crudDbContext.Database.MigrateAsync();
        }

        public Task StopAsync(CancellationToken cancellationToken)
            => Task.CompletedTask;
    }
}
