using Connector.Backend.Domain.Entities;
using System;
using System.Threading.Tasks;
using Tnf.Domain.Services;
using Product = Connector.Backend.Domain.Entities.Product;

namespace Connector.Backend.Domain.Interfaces.Services
{
    // Para que essa interface seja registrada por convenção ela precisa herdar de alguma dessas interfaces: ITransientDependency, IScopedDependency, ISingletonDependency
    public interface IProductDomainService : IDomainService
    {
        Task<Product> InsertProductAsync(Entities.Product.Builder builder);

        Task<Product> UpdateProductAsync(Entities.Product.Builder builder);

        Task DeleteProductAsync(Guid id);
    }
}
