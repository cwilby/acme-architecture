using Acme.Core.Domain.Identity;
using Acme.Data.Infrastructure;
using System.ComponentModel.Composition;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace Acme.Data.Configuration.Identity
{
    [Export(typeof(IEntityConfiguration))]
    public class UserRoleConfiguration : EntityTypeConfiguration<UserRole>, IEntityConfiguration
    {
        public UserRoleConfiguration()
        {
            HasKey(ur => new { ur.UserId, ur.RoleId });
        }

        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}
