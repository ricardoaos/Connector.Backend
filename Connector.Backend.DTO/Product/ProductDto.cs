using System;
using Tnf.Dto;
namespace Connector.Backend.DTO.Product
{
    public class ProductDto : BaseDto
    {
        public long Id { get; set; }

        public string Description { get; set; }

        public float Value { get; set; }
    }
}
