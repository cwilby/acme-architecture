using Acme.Core.Infrastructure.Interfaces;
using System;

namespace Acme.Core.Domain.Identity
{
    public class UserRole : ICreatedDate
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}
