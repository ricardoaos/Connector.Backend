using Connector.Backend.DTO.DTOs;
using Connector.Backend.DTO.Requests.RequestAll;
using System.Threading.Tasks;
using Tnf.Dto;

namespace Connector.Backend.Application.Interfaces
{
    public interface IConsumoAppService
    {
        Task<IListDto<ConsumoDTO>> GetAllWithDomainAsync(ConsumoRequestAllDTO request);
    }
}
