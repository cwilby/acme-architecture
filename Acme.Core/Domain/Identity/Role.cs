using Acme.Core.DTO.Identity;
using Acme.Core.Infrastructure.Interfaces;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Acme.Core.Domain.Identity
{
    public class Role : IRole<int>, ICreatedDate
    {
        public Role()
        {
            Users = new Collection<UserRole>();
        }
        public Role(RoleDTO role) : this()
        {
            CreatedDate = DateTime.Now;
            SetFields(role);
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual ICollection<UserRole> Users { get; set; }

        public void SetFields(RoleDTO role)
        {
            Name = role.Name;
            Description = role.Description;
        }
    }
}
