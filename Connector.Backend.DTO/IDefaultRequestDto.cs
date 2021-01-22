using System;
using Tnf.Dto;

namespace Connector.Backend.DTO
{
    public interface IDefaultRequestDto : IRequestDto
    {
        long Id { get; set; }
    }
}
