using Connector.Backend.Domain.Entities.Consumo;
using Connector.Backend.DTO.DTOs;
using Connector.Backend.DTO.Requests;
using Connector.Backend.DTO.Requests.RequestAll;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tnf.Dto;
using Tnf.Repositories;

namespace Connector.Backend.Domain.Interfaces.Repositories
{
    public interface IConsumoRepository : IRepository
    {
        Task<IListDto<ConsumoDTO>> GetAllAsync(SearchRequestAllDTO request);
    }
}
