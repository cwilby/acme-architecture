using Acme.Core.Domain.Customer;
using Acme.Core.Domain.Employee;
using Acme.Core.Domain.Identity;
using Acme.Core.Domain.Order;
using Acme.Core.Domain.Product;
using Acme.Data.Infrastructure;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Data.Entity;
using System.Reflection;

namespace Acme.Data.Context
{
    public class AcmeDataContext : DbContext
    {
        public AcmeDataContext() : base("Acme")
        {
            // https://gist.github.com/brainwipe/7661942
            var ensureDllIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        #region Customer
        public IDbSet<Customer> Customers { get; set; }
        public IDbSet<CustomerPhone> CustomerPhones { get; set; }
        public IDbSet<CustomerEmail> CustomerEmails { get; set; }
        #endregion

        #region Employee
        public IDbSet<Employee> Employees { get; set; }
        public IDbSet<EmployeePhone> EmployeePhones { get; set; }
        public IDbSet<EmployeeEmail> EmployeeEmails { get; set; }
        #endregion

        #region Identity
        public IDbSet<Role> Roles { get; set; }
        public IDbSet<User> Users { get; set; }
        public IDbSet<UserRole> UserRoles { get; set; }
        #endregion

        #region Order
        public IDbSet<Order> Orders { get; set; }
        public IDbSet<Purchase> Purchases { get; set; }
        #endregion

        #region Product
        public IDbSet<Product> Products { get; set; }
        public IDbSet<ProductPhoto> ProductPhotos { get; set; }
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // http://odetocode.com/blogs/scott/archive/2011/11/28/composing-entity-framework-fluent-configurations.aspx

            var contextConfiguration = new ContextConfiguration();
            var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            var container = new CompositionContainer(catalog);
            container.ComposeParts(contextConfiguration);

            foreach (var configuration in contextConfiguration.Configurations)
            {
                configuration.AddConfiguration(modelBuilder.Configurations);
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
