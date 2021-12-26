using System.Collections.Generic;
using System.Linq;

namespace DefaultNamespace.ProductProviders
{
    public class ProductProvider
    {
        private readonly ProductFactory _factory;
        private readonly List<Product> _products;

        public ProductProvider(ProductFactory factory, List<Product> products)
        {
            _factory = factory;
            _products = products;
        }

        public Product GetProduct(ProductId id)
        {
            var product = _products.FirstOrDefault(s => s.ProductId == id);

            if (product == null)
                product = _factory.Create(id);

            return product;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _products;
        }
    }
}