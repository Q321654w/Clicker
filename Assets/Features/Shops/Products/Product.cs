using System;

namespace DefaultNamespace
{
    [Serializable]
    public class Product
    {
        private readonly ProductId _productId;
        private readonly string _name;
        private readonly string _id;
        private readonly IPriceProvider _price;

        public Product(ProductConfig config, IPriceProvider price)
        {
            _productId = config.ProductId;
            _name = config.Name;
            _id = config.Id;
            _price = price;
        }
        
        public Product(ProductData data, IPriceProvider price)
        {
            _productId = data.ProductId;
            _name = data.Name;
            _id = data.Id;
            _price = price;
        }

        public ProductId ProductId => _productId;
        public string Name => _name;
        public string Id => _id;
        public IPriceProvider Price => _price;

        public ProductData GetData()
        {
            return new ProductData(_productId, _name, _id, _price.GetData());
        }
    }

    [Serializable]
    public readonly struct ProductData
    {
        private readonly ProductId _productId;
        private readonly string _name;
        private readonly string _id;
        private readonly PriceProviderData _priceProvider;

        public ProductData(ProductId productId, string name, string id, PriceProviderData priceProvider)
        {
            _productId = productId;
            _name = name;
            _id = id;
            _priceProvider = priceProvider;
        }

        public ProductId ProductId => _productId;
        public string Name => _name;
        public string Id => _id;
        public PriceProviderData PriceProvider => _priceProvider;
    }
}