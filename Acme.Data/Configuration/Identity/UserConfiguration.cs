using Acme.Core.Domain.Identity;
using Acme.Data.Infrastructure;
using System.ComponentModel.Composition;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace Acme.Data.Configuration.Identity
{
    [Export(typeof(IEntityConfiguration))]
    public class UserConfiguration : EntityTypeConfiguration<User>, IEntityConfiguration
    {
        public UserConfiguration()
        {
            Property(u => u.Id).HasColumnName("UserId");

            HasMany(u => u.Roles).WithRequired(ur => ur.User).HasForeignKey(ur => ur.UserId);
            HasOptional(u => u.Employee).WithOptionalDependent(u => u.User).Map(m => m.MapKey("EmployeeId"));
            HasOptional(u => u.Customer).WithOptionalDependent(u => u.User).Map(m => m.MapKey("CustomerId"));
        }

        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}
