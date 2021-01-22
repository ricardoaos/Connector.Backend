using AutoMapper;
using Connector.Backend.Domain.Entities;
using Connector.Backend.Dto.Customer;
using Connector.Backend.DTO.Product;

namespace Connector.Backend.Infra.MapperProfiles
{
    public class BasicCrudProfile : Profile
    {
        public BasicCrudProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<Product, ProductDto>();
        }
    }
}
