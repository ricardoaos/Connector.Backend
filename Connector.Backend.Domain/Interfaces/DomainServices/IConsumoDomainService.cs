using Connector.Backend.DTO.DTOs;
using Connector.Backend.DTO.Requests.RequestAll;
using System.Threading.Tasks;
using Tnf.Domain.Services;
using Tnf.Dto;

namespace Connector.Backend.Domain.Interfaces.DomainServices
{
    public interface IConsumoDomainService : IDomainService
    {
        //Task<IListDto<ConsumoDTO>> GetAllWithDomain(ConsumoRequestAllDTO request);
    }
}
