using System;
using System.Collections.Generic;
using System.Text;
using Tnf.Dto;

namespace Connector.Backend.DTO.Requests
{
    public interface IDefaultRequestDto : IRequestDto
    {
        long Id { get; set; }
    }
}
