using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Connector.Backend.DTO.DTOs;
using Tnf.Dto;
using Connector.Backend.DTO.Requests.RequestAll;

namespace Connector.Backend.Application.Interfaces
{
    public interface IConsumoAppService
    {
        Task<IListDto<ConsumoDTO>> GetAllWithDomainAsync(ConsumoRequestAllDTO request);
    }
}
