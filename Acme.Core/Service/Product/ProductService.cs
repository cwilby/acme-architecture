using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acme.Core.Infrastructure;

namespace Acme.Core.Service.Product
{
    //TODO
    public class ProductService : BaseService
    {
        public ProductService(ISession session) : base(session)
        {
        }
    }
}
