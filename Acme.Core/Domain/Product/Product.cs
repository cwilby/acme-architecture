using Acme.Core.Domain.Order;
using Acme.Core.DTO.Product;
using Acme.Core.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Acme.Core.Domain.Product
{
    public class Product : ICreatedDate
    {
        public Product()
        {
            Orders = new Collection<Purchase>();
            Photos = new Collection<ProductPhoto>();
        }
        public Product(ProductDTO product) : this()
        {
            CreatedDate = DateTime.UtcNow;
            SetFields(product);
        }
        
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public decimal RecommendedRetailPrice { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual ICollection<Purchase> Orders { get; set; }
        public virtual ICollection<ProductPhoto> Photos { get; set; }

        public void SetFields(ProductDTO product)
        {
            Name = product.Name;
            Description = product.Description;
            RecommendedRetailPrice = product.RecommendedRetailPrice;
        }
    }
}
