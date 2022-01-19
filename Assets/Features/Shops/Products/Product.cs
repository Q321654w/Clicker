namespace DefaultNamespace
{
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

        public ProductId ProductId => _productId;
        public string Name => _name;
        public string Id => _id;
        public IPriceProvider Price => _price;
    }
}