using System;
using System.Collections.Generic;
using System.Text;

namespace Connector.Backend.DTO.DTOs.Rac
{
    public class IListDto<T>
    {
        public bool hasNext { get; set; }

        public T [] items { get; set; }
    }
}
