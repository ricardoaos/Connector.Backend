using Connector.Backend.Application.Interfaces;
using Connector.Backend.Domain.Interfaces.DomainServices;
using Connector.Backend.DTO.DTOs;
using Connector.Backend.DTO.Requests.RequestAll;
using System.Linq;
using System.Threading.Tasks;
using Tnf.Application.Services;
using Tnf.Dto;
using Tnf.Notifications;
using Tnf.Repositories.Uow;

namespace Connector.Backend.Application.Services
{
    public class ConsumoAppService : ApplicationService, IConsumoAppService
    {
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IConsumoDomainService _domainService;

        public ConsumoAppService(
            IUnitOfWorkManager unitOfWorkManager,
            IConsumoDomainService domainService,
            INotificationHandler notification)
            : base(notification)
        {
            _unitOfWorkManager = unitOfWorkManager;
            _domainService = domainService;
        }

        public async Task<IListDto<ConsumoDTO>> GetAllWithDomainAsync(ConsumoRequestAllDTO request)
        {
            var retorno = await _domainService.GetAllWithDomain(request);
            retorno.Items = retorno.Items.OrderBy(p => p.Descricao).ToList();
            return retorno;
        }
    }
}
