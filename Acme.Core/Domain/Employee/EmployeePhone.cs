namespace Acme.Core.Domain.Employee
{
    public class EmployeePhone
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public PhoneTypes PhoneTypeId { get; set; }

        public string Number { get; set; }

        public virtual Employee Employee { get; set; }
    }
}