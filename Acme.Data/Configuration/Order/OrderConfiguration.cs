using Acme.Data.Infrastructure;
using System.ComponentModel.Composition;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace Acme.Data.Configuration.Order
{
    [Export(typeof(IEntityConfiguration))]
    public class OrderConfiguration : EntityTypeConfiguration<Core.Domain.Order.Order>, IEntityConfiguration
    {
        public OrderConfiguration()
        {
            Property(o => o.Id).HasColumnName("OrderId");

            HasMany(o => o.Purchases).WithRequired(p => p.Order).HasForeignKey(p => p.OrderId);
        }

        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}
