using AutoMapper;
using Northwind.Core.DTOs;
using Northwind.Core.Entities;

namespace Northwind.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();
        }

    }
}
