using Acme.Core.Domain.Employee;
using Acme.Core.DTO.Employee;
using AutoMapper;

namespace Acme.Core.Mapping
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDTO>();
            CreateMap<Employee, EmployeeDTO.WithRelations>();
            CreateMap<EmployeePhone, EmployeePhoneDTO>();
            CreateMap<EmployeeEmail, EmployeeEmailDTO>();
        }
    }
}
