using Connector.Backend.DTO.Requests.RequestAll;
using Connector.Backend.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Connector.Backend.DTO.Requests.Consumo
{
    public class ConsumoRequestAllDTO : SearchRequestAllDTO
    {
        public Constants.Dominio IdDominio { get; set; }
        public string UF { get; set; }
        public string Codigo { get; set; }
    }
}
