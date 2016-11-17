using Acme.Core.Domain.Order;
using System.Collections.Generic;

namespace Acme.Core.Domain.Product
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public decimal RecommendedRetailPrice { get; set; }

        public virtual ICollection<Purchase> Orders { get; set; }
        public virtual ICollection<ProductPhoto> Photos { get; set; }
    }
}
