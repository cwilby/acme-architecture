using Acme.Core.Infrastructure;
using Acme.Data.Context;
using System.Data.Entity;

namespace Acme.Data.Infrastructure
{
    public class MigrationsInitializer : IDatabaseInitializer
    {
        public void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AcmeDataContext, Migrations.Configuration>());
        }
    }
}
