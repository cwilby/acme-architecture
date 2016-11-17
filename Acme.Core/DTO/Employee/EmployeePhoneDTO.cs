using Acme.Core.Domain;

namespace Acme.Core.DTO.Employee
{
    public class EmployeePhoneDTO
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public PhoneTypes PhoneTypeId { get; set; }

        public string Number { get; set; }
    }
}
