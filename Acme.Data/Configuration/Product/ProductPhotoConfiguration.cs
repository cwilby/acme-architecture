using Acme.Core.Domain.Product;
using Acme.Data.Infrastructure;
using System.ComponentModel.Composition;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace Acme.Data.Configuration.Product
{
    [Export(typeof(IEntityConfiguration))]
    public class ProductPhotoConfiguration : EntityTypeConfiguration<ProductPhoto>, IEntityConfiguration
    {
        public ProductPhotoConfiguration()
        {
            Property(pp => pp.Id).HasColumnName("ProductPhotoId");
        }

        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}
