using Acme.Core.Domain.Customer;
using Acme.Core.Repository.Customer;
using Acme.Data.Infrastructure;

namespace Acme.Data.Repository.Customer
{
    public class CustomerPhoneRepository : Repository<CustomerPhone>, ICustomerPhoneRepository
    {
        public CustomerPhoneRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        { 
        }
    }
}
