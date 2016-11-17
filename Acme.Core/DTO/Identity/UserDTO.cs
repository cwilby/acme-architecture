using System.Collections.Generic;

namespace Acme.Core.DTO.Identity
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public IEnumerable<RoleDTO> Roles { get; set; }
    }
}
