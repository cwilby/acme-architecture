using Acme.Core.DTO.Employee;
using Acme.Core.Infrastructure.Interfaces;
using System;

namespace Acme.Core.Domain.Employee
{
    public class EmployeePhone : ICreatedDate
    {
        public EmployeePhone()
        {

        }
        public EmployeePhone(EmployeePhoneDTO employeePhone) : this()
        {
            CreatedDate = DateTime.Now;
            SetFields(employeePhone);
        }

        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public PhoneTypes PhoneTypeId { get; set; }

        public string Number { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual Employee Employee { get; set; }

        public void SetFields(EmployeePhoneDTO employeePhone)
        {
            PhoneTypeId = employeePhone.PhoneTypeId;
            Number = employeePhone.Number;
        }
    }
}