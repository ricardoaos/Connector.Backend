using Connector.Backend.Shared;
using Connector.Backend.Application.Interfaces;
using Connector.Backend.DTO.DTOs;
using Connector.Backend.DTO.Requests.RequestAll;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tnf.AspNetCore.Mvc.Response;
using Tnf.Dto;

namespace Connector.Backend.API.Controllers
{
    [Route(WebConstants.ConsumoName)]
    public class ConsumoController : TnfController
    {
        private readonly IConsumoAppService _appService;

        public ConsumoController(IConsumoAppService appService)
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

            return CreateResponseOnGetAll(response, WebConstants.ConsumoName);
        }
    }
}
