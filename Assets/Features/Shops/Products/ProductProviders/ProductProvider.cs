using System.Collections.Generic;
using System.Linq;

namespace DefaultNamespace.ProductProviders
{
    public class ProductProvider
    {
        private readonly ProductFactory _factory;
        private readonly List<Product> _products;

        public ProductProvider(ProductFactory factory)
        {
            _factory = factory;
            _products = factory.CreateAll();
        }
        
        public ProductProvider(ProductFactory factory, ProductProviderData data)
        {
            _factory = factory;
            _products = factory.CreateAll(data.ProductDatas);
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

        public ProductProviderData GetData()
        {
            var datas = new List<ProductData>();

            foreach (var product in _products)
            {
                datas.Add(product.GetData());
            }

            return new ProductProviderData(datas);
        }
    }
}