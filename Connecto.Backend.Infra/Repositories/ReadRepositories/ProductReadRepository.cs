using Connector.Backend.Domain.Entities;
using Connector.Backend.DTO;
using Connector.Backend.DTO.Product;
using Connector.Backend.Infra.Context;
using Connector.Backend.ReadInterfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tnf.Dto;
using Tnf.EntityFrameworkCore;
using Tnf.EntityFrameworkCore.Repositories;

namespace Connector.Backend.Infra.Repositories.ReadRepositories
{
    public class ProductReadRepository : EfCoreRepositoryBase<CrudDbContext, Product>, IProductReadRepository
    {
        public ProductReadRepository(IDbContextProvider<CrudDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<IListDto<ProductDto>> GetAllProductsAsync(ProductRequestAllDto key)
            => await GetAllAsync<ProductDto>(key, p => key.Description.IsNullOrEmpty() || p.Description.Contains(key.Description));

        public async Task<Product> GetProductAsync(DefaultRequestDto requestDto)
        {
            var entity = await GetAsync(requestDto);

            return entity;
        }

        public async Task<Product> GetProductAsync(long id)
        {
            var entity = await FirstOrDefaultAsync(p => p.Id == id);

            return entity;
        }
    }
}
