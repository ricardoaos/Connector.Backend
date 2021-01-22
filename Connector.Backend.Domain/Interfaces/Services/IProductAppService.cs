﻿using Connector.Backend.DTO;
using Connector.Backend.DTO.Product;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Threading.Tasks;
using Tnf.Application.Services;
using Tnf.Dto;

namespace BasicCrud.Application.Services.Interfaces
{
    // Para que essa interface seja registrada por convenção ela precisa herdar de alguma dessas interfaces: ITransientDependency, IScopedDependency, ISingletonDependency
    public interface IProductAppService : IApplicationService
    {
        Task<ProductDto> CreateProductAsync(ProductDto product);
        Task<ProductDto> UpdateProductAsync(Guid id, ProductDto product);
        Task<ProductDto> PatchProductAsync(Guid id, JsonPatchDocument productPatch);
        Task<IListDto<ProductDto>> ResetAllProductAsync(ProductRequestAllDto request);
        Task DeleteProductAsync(Guid id);
        Task<ProductDto> GetProductAsync(DefaultRequestDto id);
        Task<IListDto<ProductDto>> GetAllProductAsync(ProductRequestAllDto request);
    }
}