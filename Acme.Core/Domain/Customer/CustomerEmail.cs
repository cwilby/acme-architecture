using Acme.Core.DTO.Customer;
using Acme.Core.Infrastructure.Interfaces;
using System;

namespace Acme.Core.Domain.Customer
{
    public class CustomerEmail : ICreatedDate
    {
        public CustomerEmail()
        {

        }
        public CustomerEmail(CustomerEmailDTO customerEmail) : this()
        {
            CreatedDate = DateTime.UtcNow;

            SetFields(customerEmail);
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }

        public bool IsPrimary { get; set; }
        public string Address { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual Customer Customer { get; set; }

        public void SetFields(CustomerEmailDTO customerEmail)
        {
            IsPrimary = customerEmail.IsPrimary;
            Address = customerEmail.Address;
        }
    }
}
