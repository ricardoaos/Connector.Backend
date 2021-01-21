using Connector.Backend.Application.Interfaces;
using Connector.Backend.Application.Services;
using Connector.Backend.Domain;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Connector.Backend.Application
{
    public class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServiceDependency(this IServiceCollection services)
        {
            // Dependencia do projeto BasicCrud.Domain
            services.AddDomainDependency();

            // Para habilitar as convenções do Tnf para Injeção de dependência (ITransientDependency, IScopedDependency, ISingletonDependency)
            // descomente a linha abaixo:
            // services.AddTnfDefaultConventionalRegistrations();

            // Registro dos serviços
            services.AddTransient<IConsumoAppService, ConsumoAppService>();

            return services;
        }
    }
}
