using System.Collections.Generic;

namespace DefaultNamespace
{
    public class ProductFactory
    {
        private readonly Inventory _inventory;
        private readonly ProductDataBase _dataBase;

        public ProductFactory(Inventory inventory, ProductDataBase dataBase)
        {
            _inventory = inventory;
            _dataBase = dataBase;
        }
        
        public List<Product> CreateAll()
        {
            var products = new List<Product>();

            foreach (var config in _dataBase.ProductConfigs)
            {
                var priceProvider = new CountScalingPrice(_inventory, config.BasePrice, config.Id);
                var product = new Product(config, priceProvider);
                products.Add(product);
            }

            return products;
        }

        public Product Create(ProductId id)
        {
            var config = _dataBase.GetProductConfig(id);
            var priceProvider = new CountScalingPrice(_inventory, config.BasePrice, config.Id);
            var product = new Product(config, priceProvider);
            return product;
        }
    }
}