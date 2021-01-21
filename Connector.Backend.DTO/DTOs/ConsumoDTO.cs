using System;
using Tnf.Dto;

namespace Connector.Backend.DTO.DTOs
{
    public partial class ConsumoDTO : BaseDto
    {
        public string UF { get; set; }
        public long Codigo { get; set; }
        public string Descricao { get; set; }

        public long Value { get
            {
                return this.Codigo;
            } }

        public string Label
        {
            get
            {
                return this.Descricao;
            }
        }

    }
}
