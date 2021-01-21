using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tnf.Domain.Services;
using Tnf.Dto;

namespace Connector.Backend.Domain.Interfaces.DomainServices
{
    public interface IConsumoDomainService : IDomainService
    {
        Task<IListDto<ConsumoDTO>> GetAllWithDomain(ConsumoRequestAllDTO request);
    }
}
