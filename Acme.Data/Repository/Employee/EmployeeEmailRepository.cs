using Acme.Core.Domain.Employee;
using Acme.Core.Repository.Employee;
using Acme.Data.Infrastructure;

namespace Acme.Data.Repository.Employee
{
    public class EmployeeEmailRepository : Repository<EmployeeEmail>, IEmployeeEmailRepository
    {
        public EmployeeEmailRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        { 
        }
    }
}
