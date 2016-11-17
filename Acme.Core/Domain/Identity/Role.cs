using Microsoft.AspNet.Identity;
using System.Collections.Generic;

namespace Acme.Core.Domain.Identity
{
    public class Role : IRole<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UserRole> Users { get; set; }
    }
}
