using Acme.Core.Domain.Order;
using Acme.Core.Repository.Order;
using Acme.Data.Infrastructure;

namespace Acme.Data.Repository.Order
{
    public class OrderRepository : Repository<Core.Domain.Order.Order>, IOrderRepository
    {
        public OrderRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        { 
        }
    }
}
