using System.Data.Entity.ModelConfiguration.Configuration;

namespace Acme.Data.Infrastructure
{
    public interface IEntityConfiguration
    {
        void AddConfiguration(ConfigurationRegistrar registrar);
    }
}
