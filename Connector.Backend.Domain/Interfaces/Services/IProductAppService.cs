using Connector.Backend.DTO;
using Connector.Backend.DTO.Product;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Threading.Tasks;
using Tnf.Application.Services;
using Tnf.Dto;

namespace Connector.Backend.Application.Services.Interfaces
{
    // Para que essa interface seja registrada por convenção ela precisa herdar de alguma dessas interfaces: ITransientDependency, IScopedDependency, ISingletonDependency
    public interface IProductAppService : IApplicationService
    {
        Task<ProductDto> CreateProductAsync(ProductDto product);
        Task<ProductDto> UpdateProductAsync(long id, ProductDto product);
        Task<ProductDto> PatchProductAsync(long id, JsonPatchDocument productPatch);
        Task<IListDto<ProductDto>> ResetAllProductAsync(ProductRequestAllDto request);
        Task DeleteProductAsync(long id);
        Task<ProductDto> GetProductAsync(DefaultRequestDto id);
        Task<IListDto<ProductDto>> GetAllProductAsync(ProductRequestAllDto request);
    }
}
