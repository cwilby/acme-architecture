using Acme.Core.Domain.Order;
using Acme.Data.Infrastructure;
using System.ComponentModel.Composition;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace Acme.Data.Configuration.Order
{
    [Export(typeof(IEntityConfiguration))]
    public class PurchaseConfiguration : EntityTypeConfiguration<Purchase>, IEntityConfiguration
    {
        public PurchaseConfiguration()
        {
            HasKey(p => new { p.OrderId, p.ProductId });
        }

        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}
