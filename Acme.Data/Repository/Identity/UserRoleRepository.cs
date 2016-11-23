using Acme.Core.Domain.Identity;
using Acme.Core.Repository.Identity;
using Acme.Data.Infrastructure;

namespace Acme.Data.Repository.Identity
{
    public class UserRoleRepository : Repository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        { 
        }
    }
}
