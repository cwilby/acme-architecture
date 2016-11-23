using Acme.Core.Domain.Employee;
using Acme.Core.Infrastructure;

namespace Acme.Core.Repository.Employee
{
	public interface IEmployeeEmailRepository : IRepository<EmployeeEmail>
	{
	}
}