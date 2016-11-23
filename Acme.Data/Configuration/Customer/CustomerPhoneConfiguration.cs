using Acme.Core.Domain.Customer;
using Acme.Data.Infrastructure;
using System.ComponentModel.Composition;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace Acme.Data.Configuration.Customer
{
    [Export(typeof(IEntityConfiguration))]
    public class CustomerPhoneConfiguration : EntityTypeConfiguration<CustomerPhone>, IEntityConfiguration
    {
        public CustomerPhoneConfiguration()
        {
            Property(cp => cp.Id).HasColumnName("CustomerPhoneId");
        }

        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}
