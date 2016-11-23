using Acme.Core.Domain.Identity;
using Acme.Core.Infrastructure;

namespace Acme.Core.Repository.Identity
{
	public interface IUserRepository : IRepository<User>
	{
	}
}