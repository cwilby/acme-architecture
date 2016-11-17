namespace Acme.Core.Domain.Employee
{
    public class EmployeeEmail
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }

        public string Address { get; set; }

        public virtual Employee Employee { get; set; }
    }
}