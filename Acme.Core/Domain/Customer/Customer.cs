using Acme.Core.Domain.Identity;
using Acme.Core.DTO.Customer;
using Acme.Core.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Acme.Core.Domain.Customer
{
    public class Customer : ICreatedDate
    {
        public Customer()
        {
            Emails = new Collection<CustomerEmail>();
            Phones = new Collection<CustomerPhone>();
        }
        public Customer(CustomerDTO customer) : this()
        {
            CreatedDate = DateTime.UtcNow;
            SetFields(customer);
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

        public virtual ICollection<CustomerEmail> Emails { get; set; }
        public virtual ICollection<CustomerPhone> Phones { get; set; }
        public virtual ICollection<Order.Order> Orders { get; set; }

        public void SetFields(CustomerDTO customer)
        {
            FirstName = customer.FirstName;
            LastName = customer.LastName;

            Address1 = customer.Address1;
            Address2 = customer.Address2;
            City = customer.City;
            State = customer.State;
            Zip = customer.Zip;
        }
    }
}
