using Acme.Core.Domain.Customer;
using Acme.Core.Repository.Customer;
using Acme.Data.Infrastructure;

namespace Acme.Data.Repository.Customer
{
    public class CustomerEmailRepository : Repository<CustomerEmail>, ICustomerEmailRepository
    {
        public CustomerEmailRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        { 
        }
    }
}
