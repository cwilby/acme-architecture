using Acme.Core.DTO.Employee;
using Acme.Core.Infrastructure.Interfaces;
using System;

namespace Acme.Core.Domain.Employee
{
    public class EmployeeEmail : ICreatedDate
    {
        public EmployeeEmail()
        {

        }
        public EmployeeEmail(EmployeeEmailDTO employeeEmail) : this()
        {
            CreatedDate = DateTime.Now;
            SetFields(employeeEmail);
        }

        public int Id { get; set; }
        public int EmployeeId { get; set; }

        public string Address { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual Employee Employee { get; set; }

        public void SetFields(EmployeeEmailDTO employeeEmail)
        {
            Address = employeeEmail.Address;
        }
    }
}