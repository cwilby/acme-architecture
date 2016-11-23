using Acme.Core.Domain.Customer;
using Acme.Core.DTO.Customer;
using AutoMapper;

namespace Acme.Core.Mapping
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDTO>();
            CreateMap<Customer, CustomerDTO.WithRelations>();

            CreateMap<CustomerPhone, CustomerPhoneDTO>();

            CreateMap<CustomerEmail, CustomerEmailDTO>();
        }
    }
}
