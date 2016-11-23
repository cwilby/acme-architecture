using Acme.Core.Domain.Identity;
using Acme.Core.Repository.Identity;
using Acme.Data.Infrastructure;

namespace Acme.Data.Repository.Identity
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        { 
        }
    }
}
