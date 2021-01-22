using Connector.Backend.Domain.Entities;
using Connector.Backend.Domain.Interfaces.Repositories;
using Connector.Backend.Infra.Context;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Tnf.EntityFrameworkCore;
using Tnf.EntityFrameworkCore.Repositories;

namespace Connector.Backend.Infra
{
    public class ProductRepository : EfCoreRepositoryBase<CrudDbContext, Product>, IProductRepository
    {
        public ProductRepository(IDbContextProvider<CrudDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task DeleteProductAsync(long id)
            => await DeleteAsync(w => w.Id == id);

        public async Task<Product> InsertProductAndGetIdAsync(Product product)
            => await InsertAndSaveChangesAsync(product);

        public async Task<Product> UpdateProductAsync(Product product, params Expression<Func<Product, object>>[] changedProperties)
            => await UpdateAsync(product, changedProperties);
    }
}
