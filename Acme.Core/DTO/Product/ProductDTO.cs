using System.Collections.Generic;

namespace Acme.Core.DTO.Product
{
    public class ProductDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public decimal RecommendedRetailPrice { get; set; }

        public class WithRelations : ProductDTO
        {
            public IEnumerable<ProductPhotoDTO> Photos { get; set; }
        }
    }
}
