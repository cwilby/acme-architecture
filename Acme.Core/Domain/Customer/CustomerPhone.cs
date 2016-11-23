using Acme.Core.DTO.Customer;
using Acme.Core.Infrastructure.Interfaces;
using System;

namespace Acme.Core.Domain.Customer
{
    public class CustomerPhone : ICreatedDate
    {
        public CustomerPhone()
        {

        }
        public CustomerPhone(CustomerPhoneDTO customerPhone) : this()
        {
            CreatedDate = DateTime.Now;
            Update(customerPhone);
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public PhoneTypes PhoneTypeId { get; set; }

        public string Number { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual Customer Customer { get; set; }

        public void Update(CustomerPhoneDTO customerPhone)
        {
            PhoneTypeId = customerPhone.PhoneTypeId;
            Number = customerPhone.Number;
        }
    }
}
