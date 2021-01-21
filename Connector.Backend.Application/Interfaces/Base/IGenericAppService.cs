using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
