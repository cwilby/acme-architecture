using Acme.Core.Extensions;
using Acme.Core.Service.Customer;
using SimpleInjector;
using SimpleInjector.Packaging;
using System.Linq;

namespace Acme.Api.Injection
{
    public class ServicePackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            typeof(CustomerService).Assembly.GetExportedTypes()
              .Where(t => t.Namespace.Contains("Acme.Core.Service") && t.GetInterfaces().Any())
              .Select(t => new { Service = t.GetInterfaces().First(), Implementation = t })
              .ForEach(reg => container.Register(reg.Service, reg.Implementation, Lifestyle.Transient));
        }
    }
}