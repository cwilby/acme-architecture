using Acme.Core.Domain.Customer;
using Acme.Core.Infrastructure;

namespace Acme.Core.Repository.Customer
{
	public interface ICustomerRepository : IRepository<Core.Domain.Customer.Customer>
	{
	}
}