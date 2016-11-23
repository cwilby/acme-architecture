using Acme.Core.Domain.Product;
using Acme.Data.Infrastructure;
using System.ComponentModel.Composition;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace Acme.Data.Configuration.Product
{
    [Export(typeof(IEntityConfiguration))]
    public class ProductConfiguration : EntityTypeConfiguration<Core.Domain.Product.Product>, IEntityConfiguration
    {
        public ProductConfiguration()
        {
            Property(p => p.Id).HasColumnName("ProductId");

            HasMany(p => p.Photos).WithRequired(pp => pp.Product).HasForeignKey(pp => pp.ProductId);
            HasMany(p => p.Orders).WithRequired(p => p.Product).HasForeignKey(p => p.ProductId);
        }

        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}
