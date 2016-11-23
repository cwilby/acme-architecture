using Acme.Core.Domain.Employee;
using Acme.Data.Infrastructure;
using System.ComponentModel.Composition;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace Acme.Data.Configuration.Employee
{
    [Export(typeof(IEntityConfiguration))]
    public class EmployeePhoneConfiguration : EntityTypeConfiguration<EmployeePhone>, IEntityConfiguration
    {
        public EmployeePhoneConfiguration()
        {
            Property(ep => ep.Id).HasColumnName("EmployeePhoneId");
        }

        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}
