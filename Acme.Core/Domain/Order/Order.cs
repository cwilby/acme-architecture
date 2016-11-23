using Acme.Core.DTO.Order;
using Acme.Core.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Acme.Core.Domain.Order
{
    public class Order : ICreatedDate
    {
        public Order()
        {
            Purchases = new Collection<Purchase>();
        }
        public Order(OrderDTO order) : this()
        {
            CreatedDate = DateTime.UtcNow;
            CustomerId = order.CustomerId;
            SetFields(order);
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        
        public DateTime CreatedDate { get; set; }

        public virtual Customer.Customer Customer { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; } 

        public void SetFields(OrderDTO order)
        {

        }
    }
}
