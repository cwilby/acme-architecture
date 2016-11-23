using Acme.Core.Domain.Product;
using Acme.Core.Repository.Product;
using Acme.Data.Infrastructure;

namespace Acme.Data.Repository.Product
{
    public class ProductPhotoRepository : Repository<ProductPhoto>, IProductPhotoRepository
    {
        public ProductPhotoRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        { 
        }
    }
}
