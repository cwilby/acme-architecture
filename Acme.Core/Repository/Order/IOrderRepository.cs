using Acme.Core.Domain.Order;
using Acme.Core.Infrastructure;

namespace Acme.Core.Repository.Order
{
	public interface IOrderRepository : IRepository<Core.Domain.Order.Order>
	{
	}
}