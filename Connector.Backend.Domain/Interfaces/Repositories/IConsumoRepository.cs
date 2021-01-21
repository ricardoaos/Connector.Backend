using Connector.Backend.Domain.Entities.Consumo;
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
        Task<Consumo> InsertAsync(Consumo entity);
        Task<Consumo> UpdateAsync(Consumo entity);
        Task<bool> DeleteAsync(long Id);
        Task<IListDto<ConsumoDTO>> GetAllAsync(SearchRequestAllDTO request);
        Task<IListDto<ConsumoDTO>> GetAllWithDomain(ConsumoRequestAllDTO request);
        Task<ConsumoDTO> GetAsync(DefaultRequestDto key);
        Task<Consumo> FindByIdAsync(long Id);
    }
}
