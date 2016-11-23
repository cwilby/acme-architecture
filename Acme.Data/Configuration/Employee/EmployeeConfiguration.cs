using Acme.Core.Domain.Employee;
using Acme.Data.Infrastructure;
using System.ComponentModel.Composition;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace Acme.Data.Configuration.Employee
{
    [Export(typeof(IEntityConfiguration))]
    public class EmployeeConfiguration : EntityTypeConfiguration<Core.Domain.Employee.Employee>, IEntityConfiguration
    {
        public EmployeeConfiguration()
        {
            Property(e => e.Id).HasColumnName("EmployeeId");

            HasMany(e => e.Phones).WithRequired(ep => ep.Employee).HasForeignKey(ep => ep.EmployeeId);
            HasMany(e => e.Emails).WithRequired(ee => ee.Employee).HasForeignKey(ee => ee.EmployeeId);
        }

        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}
