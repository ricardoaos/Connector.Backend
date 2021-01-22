using System;
using Tnf.Dto;

namespace Connector.Backend.DTO.Customer
{
    public class DefaultRequestDto : BaseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}