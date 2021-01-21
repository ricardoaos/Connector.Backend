using Connector.Backend.Domain.Configurations;
using Connector.Backend.Domain.Entities.Consumo;
using Connector.Backend.Domain.Interfaces.DomainServices;
using Connector.Backend.Domain.Interfaces.Repositories;
using Connector.Backend.DTO.DTOs;
using Connector.Backend.DTO.Requests;
using Connector.Backend.DTO.Requests.RequestAll;
using System.Threading.Tasks;
using Tnf.Domain.Services;
using Tnf.Dto;
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


        protected Consumo BuildEntity(Consumo.Builder builder) =>
            builder.Build();
    }
}
