using Acme.Core.Domain.Identity;
using Acme.Core.DTO.Employee;
using Acme.Core.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Acme.Core.Domain.Employee
{
    public class Employee : ICreatedDate
    {
        public Employee()
        {
            Emails = new Collection<EmployeeEmail>();
            Phones = new Collection<EmployeePhone>();
        }
        public Employee(EmployeeDTO employee) : this()
        {
            CreatedDate = DateTime.Now;
            SetFields(employee);
        }
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<EmployeeEmail> Emails { get; set; }
        public virtual ICollection<EmployeePhone> Phones { get; set; }

        public void SetFields(EmployeeDTO employee)
        {
            FirstName = employee.FirstName;
            LastName = employee.LastName;
            Address1 = employee.Address1;
            Address2 = employee.Address2;
            City = employee.City;
            State = employee.State;
            Zip = employee.Zip;
        }
    }
}
