using Acme.Core.Domain.Product;
using Acme.Core.Infrastructure;

namespace Acme.Core.Repository.Product
{
	public interface IProductRepository : IRepository<Core.Domain.Product.Product>
	{
	}
}