using System;
using System.Collections.Generic;
using System.Text;

namespace Connector.Backend.Application.Services
{
    public class ConsumoAppService : ApplicationService, IConsumoAppService
    {
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IDominioExternoDomainService _domainService;

        public DominioExternoAppService(
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
