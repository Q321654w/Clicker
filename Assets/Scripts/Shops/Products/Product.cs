namespace DefaultNamespace
{
    public class Product
    {
        private readonly ProductId _productId;
        private readonly string _name;
        private readonly string _id;
        private readonly IPriceProvider _priceProvider;

        public Product(ProductConfig config, IPriceProvider priceProvider)
        {
            _productId = config.ProductId;
            _name = config.Name;
            _id = config.Id;
            _priceProvider = priceProvider;
        }

        public ProductId ProductId => _productId;
        public string Name => _name;
        public string Id => _id;
        public IPriceProvider PriceProvider => _priceProvider;
    }
}