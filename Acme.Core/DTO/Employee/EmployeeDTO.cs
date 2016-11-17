using Acme.Core.Domain.Employee;
using System.Collections.Generic;

namespace Acme.Core.DTO.Employee
{
    public class EmployeeDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Could be refactored into a seperate `Address.cs` file also.
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public class WithRelations : EmployeeDTO
        {
            public IEnumerable<EmployeeEmail> Emails { get; set; }
            public IEnumerable<EmployeePhone> Phones { get; set; }
        }
    }
}
