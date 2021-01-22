using System;
using Tnf.Dto;

namespace Connector.Backend.DTO
{
    public interface IDefaultRequestDto : IRequestDto
    {
        Guid Id { get; set; }
    }
}
