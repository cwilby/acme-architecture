using Acme.Core.Domain.Identity;
using Acme.Core.DTO.Identity;
using AutoMapper;

namespace Acme.Core.Mapping
{
    public class IdentityProfile : Profile
    {
        public IdentityProfile()
        {
            CreateMap<Role, RoleDTO>();
            CreateMap<User, UserDTO>();
        }
    }
}
