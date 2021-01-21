using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tnf.AspNetCore.Mvc.Response;
using Tnf.Dto;

namespace Connector.Backend.API.Controllers
{
    public class ConsumoController : Controller
    {
        private readonly IConsumoAppService _appService;

        public DominioController(IConsumoAppService appService)
        {
            _appService = appService;
        }


        /// <summary>
        /// Get all
        /// </summary>
        /// <returns>List</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IListDto<ConsumoDTO>), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> GetAll([FromQuery] string filter, [FromQuery] Constants.Dominio dominio, [FromQuery] string uf)
        {

            ConsumoRequestAllDTO request = new ConsumoRequestAllDTO
            {
                IdDominio = dominio,
                Page = 1,
                PageSize = 999,
                Search = filter,
                UF = (uf == "undefined" ? null : uf)
            };

            var response = await _appService.GetAllWithDomainAsync(request);

            return CreateResponseOnGetAll(response, WebConstants.DominioRouteName);
        }
    }
}
