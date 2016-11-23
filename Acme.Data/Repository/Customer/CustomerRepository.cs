using Acme.Core.Domain.Customer;
using Acme.Core.Repository.Customer;
using Acme.Data.Infrastructure;

namespace Acme.Data.Repository.Customer
{
    public class CustomerRepository : Repository<Core.Domain.Customer.Customer>, ICustomerRepository
    {
        public CustomerRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        { 
        }
    }
}
