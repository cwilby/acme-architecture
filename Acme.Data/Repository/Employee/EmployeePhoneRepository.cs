using Acme.Core.Domain.Employee;
using Acme.Core.Repository.Employee;
using Acme.Data.Infrastructure;

namespace Acme.Data.Repository.Employee
{
    public class EmployeePhoneRepository : Repository<EmployeePhone>, IEmployeePhoneRepository
    {
        public EmployeePhoneRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        { 
        }
    }
}
