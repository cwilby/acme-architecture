using Acme.Core.Domain.Employee;
using Acme.Data.Infrastructure;
using System.ComponentModel.Composition;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace Acme.Data.Configuration.Employee
{
    [Export(typeof(IEntityConfiguration))]
    public class EmployeeEmailConfiguration : EntityTypeConfiguration<EmployeeEmail>, IEntityConfiguration
    {
        public EmployeeEmailConfiguration()
        {
            Property(ee => ee.Id).HasColumnName("EmployeeEmailId");
        }

        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}
