using Acme.Core.Domain.Order;
using Acme.Core.Repository.Order;
using Acme.Data.Infrastructure;

namespace Acme.Data.Repository.Order
{
    public class PurchaseRepository : Repository<Purchase>, IPurchaseRepository
    {
        public PurchaseRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        { 
        }
    }
}
