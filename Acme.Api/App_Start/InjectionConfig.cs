using Acme.Api.Infrastructure;
using Acme.Core.Domain.Identity;
using Acme.Core.Extensions;
using Acme.Core.Infrastructure;
using Acme.Core.Repository.Identity;
using Acme.Data.Identity;
using Acme.Data.Infrastructure;
using Acme.Data.Repository.Identity;
using Microsoft.AspNet.Identity;
using Owin;
using SimpleInjector;
using SimpleInjector.Extensions.ExecutionContextScoping;
using System.Linq;

namespace Acme.Api
{
    public partial class Startup
    {
        public Container ConfigureSimpleInjector(IAppBuilder app)
        {
            var container = new Container();

            container.Options.DefaultScopedLifestyle = new ExecutionContextScopeLifestyle();

            container.RegisterPackages();  

            app.Use(async (context, next) =>
            {
                using (container.BeginExecutionContextScope())
                {
                    await next();
                }
            });

            container.Verify();

            return container;
        }
    }
}