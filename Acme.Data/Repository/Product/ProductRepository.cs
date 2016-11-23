using Acme.Core.Domain.Product;
using Acme.Core.Repository.Product;
using Acme.Data.Infrastructure;

namespace Acme.Data.Repository.Product
{
    public class ProductRepository : Repository<Core.Domain.Product.Product>, IProductRepository
    {
        public ProductRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        { 
        }
    }
}
