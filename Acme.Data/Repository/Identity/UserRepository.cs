using Acme.Core.Domain.Identity;
using Acme.Core.Repository.Identity;
using Acme.Data.Infrastructure;

namespace Acme.Data.Repository.Identity
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        { 
        }
    }
}
