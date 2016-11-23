using Acme.Core.Domain.Employee;
using Acme.Core.Repository.Employee;
using Acme.Data.Infrastructure;

namespace Acme.Data.Repository.Employee
{
    public class EmployeeRepository : Repository<Core.Domain.Employee.Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        { 
        }
    }
}
