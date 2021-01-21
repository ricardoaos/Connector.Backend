using Connector.Backend.Domain.Configurations;
using Connector.Backend.Domain.Entities.Consumo;
using Connector.Backend.Domain.Interfaces.DomainServices;
using Connector.Backend.Domain.Interfaces.Repositories;
using Connector.Backend.DTO.DTOs;
using Connector.Backend.DTO.DTOs.Rac;
using Connector.Backend.DTO.Requests;
using Connector.Backend.DTO.Requests.Consumo;
using Connector.Backend.DTO.Requests.RequestAll;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tnf.Domain.Services;
using Tnf.Notifications;

namespace Connector.Backend.Domain.DomainServices
{
    public class ConsumoDomainService : DomainService, IConsumoDomainService
    {
        protected readonly IConsumoRepository _repository;

        public ConsumoDomainService(IConsumoRepository repository, INotificationHandler notificationHandler)
            : base(notificationHandler)
        {
            _repository = repository;
        }
      
        public async virtual Task<IListDto<ConsumoDTO>> GetAllAsync(SearchRequestAllDTO request) =>
            await _repository.GetAllAsync(request);        

        public async virtual Task<ConsumoDTO> GetAsync(DefaultRequestDto key) =>
            await _repository.GetAsync(key);

        protected Consumo BuildEntity(Consumo.Builder builder) =>
            builder.Build();
    }
}
