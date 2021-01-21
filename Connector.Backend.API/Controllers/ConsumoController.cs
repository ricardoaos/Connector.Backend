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
        private readonly IDominioExternoAppService _appService;

        public DominioController(IDominioExternoAppService appService)
        {
            _appService = appService;
        }


        /// <summary>
        /// Get all
        /// </summary>
        /// <returns>List</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IListDto<DominioExternoDTO>), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> GetAll([FromQuery] string filter, [FromQuery] Constants.Dominio dominio, [FromQuery] string uf)
        {

            DominioExternoRequestAllDTO request = new DominioExternoRequestAllDTO
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
