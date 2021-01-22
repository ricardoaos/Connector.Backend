using Connector.Backend.Domain.Entities;
using Connector.Backend.DTO;
using Connector.Backend.DTO.Product;
using System;
using System.Threading.Tasks;
using Tnf.Dto;
using Tnf.Repositories;

namespace Connector.Backend.ReadInterfaces
{
    // Para que essa interface seja registrada por convenção ela precisa herdar de alguma dessas interfaces: ITransientDependency, IScopedDependency, ISingletonDependency
    public interface IProductReadRepository : IRepository
    {
        Task<Product> GetProductAsync(DefaultRequestDto key);

        Task<Product> GetProductAsync(long id);

        Task<IListDto<ProductDto>> GetAllProductsAsync(ProductRequestAllDto key);
    }
}
