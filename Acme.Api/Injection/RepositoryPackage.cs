using Acme.Core.Extensions;
using Acme.Data.Repository.Identity;
using SimpleInjector;
using SimpleInjector.Packaging;
using System.Linq;

namespace Acme.Api.Injection
{
    public class RepositoryPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            typeof(UserRepository).Assembly.GetExportedTypes()
              .Where(t => t.Namespace.Contains("Acme.Data.Repository") && t.GetInterfaces().Any())
              .Select(t => new { Service = t.GetInterfaces().ElementAt(1), Implementation = t })
              .ForEach(reg => container.Register(reg.Service, reg.Implementation, Lifestyle.Transient));
        }
    }
}