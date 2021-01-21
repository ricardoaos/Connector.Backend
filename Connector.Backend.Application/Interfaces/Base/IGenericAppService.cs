using Connector.Backend.DTO.Requests;
using Connector.Backend.DTO.Requests.RequestAll;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tnf.Application.Services;
using Tnf.Dto;

namespace Connector.Backend.Application.Interfaces.Base
{
    public interface IGenericAppService<TDto> : IApplicationService where TDto : BaseDto
    {
        Task<TDto> CreateAsync(TDto dto);
        Task<TDto> UpdateAsync(long Id, TDto dto);
        Task DeleteAsync(long Id);
        Task<TDto> GetAsync(DefaultRequestDto id);
        Task<IListDto<TDto>> GetAllAsync(SearchRequestAllDTO request);
    }
}
