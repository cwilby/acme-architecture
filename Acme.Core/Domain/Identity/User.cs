using Microsoft.AspNet.Identity;
using System.Collections.Generic;

namespace Acme.Core.Domain.Identity
{
    public class User : IUser<int>
    {
        public int Id { get; set; }

        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }

        public virtual Employee.Employee Employee { get; set; }
        public virtual Customer.Customer Customer { get; set; }

        public virtual ICollection<UserRole> Roles { get; set; }
    }
}
