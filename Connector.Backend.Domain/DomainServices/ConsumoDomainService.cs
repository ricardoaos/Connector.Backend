using Connector.Backend.Domain.Configurations;
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

        public async virtual Task<bool> DeleteAsync(long Id) =>
           await _repository.DeleteAsync(Id);

        public async virtual Task<Consumo> FindByIdAsync(long Id) =>
            await _repository.FindByIdAsync(Id);



        public async virtual Task<IListDto<ConsumoDTO>> GetAllAsync(SearchRequestAllDTO request) =>
            await _repository.GetAllAsync(request);

        public async virtual Task<IListDto<ConsumoDTO>> GetAllWithDomain(ConsumoRequestAllDTO request)
        {
            return await _repository.GetAllWithDomain(request);
        }

        public async virtual Task<ConsumoDTO> GetAsync(DefaultRequestDto key) =>
            await _repository.GetAsync(key);

        public virtual async Task<Consumo> InsertAsync(Consumo.Builder builder)
        {
            if (builder == null)
            {
                Notification.RaiseError(Constants.LocalizationSourceName,
                    Error.DomainServiceOnUpdateNullBuilderError);
                return default;
            }

            var entity = BuildEntity(builder);

            if (Notification.HasNotification())
                return default;

            return await _repository.InsertAsync(entity);
        }

        public virtual async Task<Consumo> UpdateAsync(Consumo.Builder builder)
        {
            if (builder == null)
            {
                Notification.RaiseError(Constants.LocalizationSourceName,
                    Error.DomainServiceOnUpdateNullBuilderError);
                return default;
            }

            var entity = BuildEntity(builder);

            if (Notification.HasNotification())
                return default;

            return await _repository.UpdateAsync(entity);
        }

        protected Consumo BuildEntity(Consumo.Builder builder) =>
            builder.Build();
    }
}
