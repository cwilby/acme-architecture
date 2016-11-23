using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acme.Core.Infrastructure;

namespace Acme.Core.Service.Employee
{
    //TODO
    public class EmployeeService : BaseService
    {
        public EmployeeService(ISession session) : base(session)
        {
        }
    }
}
