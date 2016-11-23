using Acme.Api.Infrastructure;
using Acme.Core.Domain.Identity;
using Acme.Core.Infrastructure;
using Acme.Core.Repository.Identity;
using Acme.Data.Identity;
using Microsoft.AspNet.Identity;
using SimpleInjector;
using SimpleInjector.Packaging;

namespace Acme.Api.Injection
{
    public class IdentityPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<IUserStore<User, int>, UserStore>(Lifestyle.Scoped);
            container.Register<IAuthorizationRepository, AuthorizationRepository>(Lifestyle.Scoped);
            container.Register<ISession, Session>();
        }
    }
}