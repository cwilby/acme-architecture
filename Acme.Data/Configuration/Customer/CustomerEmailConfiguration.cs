using Acme.Core.Domain.Customer;
using Acme.Data.Infrastructure;
using System.ComponentModel.Composition;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace Acme.Data.Configuration.Customer
{
    [Export(typeof(IEntityConfiguration))]
    public class CustomerEmailConfiguration : EntityTypeConfiguration<CustomerEmail>, IEntityConfiguration
    {
        public CustomerEmailConfiguration()
        {
            Property(ce => ce.Id).HasColumnName("CustomerEmailId");
        }

        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}
