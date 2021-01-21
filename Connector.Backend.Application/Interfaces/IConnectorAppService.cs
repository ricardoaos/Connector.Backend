using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Connector.Backend.Application.Interfaces
{
    public interface IConnectorAppService
    {
        Task<IListDto<ConsumoDTO>> GetAllWithDomainAsync(ConsumoRequestAllDTO request);
    }
}
