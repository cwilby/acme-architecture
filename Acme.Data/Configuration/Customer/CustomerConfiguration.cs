using Acme.Data.Infrastructure;
using System.ComponentModel.Composition;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace Acme.Data.Configuration.Customer
{
    [Export(typeof(IEntityConfiguration))]
    public class CustomerConfiguration : EntityTypeConfiguration<Core.Domain.Customer.Customer>, IEntityConfiguration
    {
        public CustomerConfiguration()
        {
            Property(c => c.Id).HasColumnName("CustomerId");

            HasMany(c => c.Emails).WithRequired(ce => ce.Customer).HasForeignKey(ce => ce.CustomerId);
            HasMany(c => c.Phones).WithRequired(cp => cp.Customer).HasForeignKey(cp => cp.CustomerId);
            HasMany(c => c.Orders).WithRequired(o => o.Customer).HasForeignKey(o => o.CustomerId);
        }

        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}
