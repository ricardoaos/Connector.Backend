using Connector.Backend.Domain.Entities;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Tnf.Repositories;

namespace Connector.Backend.Domain.Interfaces.Repositories
{
    // Para que essa interface seja registrada por convenção ela precisa herdar de alguma dessas interfaces: ITransientDependency, IScopedDependency, ISingletonDependency
    public interface IProductRepository : IRepository
    {
        Task<Product> InsertProductAndGetIdAsync(Product product);

        Task<Product> UpdateProductAsync(Product product, params Expression<Func<Product, object>>[] changedProperties);

        Task DeleteProductAsync(long id);
    }
}
