using System;
using System.Collections.Generic;
using DefaultNamespace.ProductProviders;

namespace DefaultNamespace
{
    public class Shop
    {
        private readonly ProductProvider _productProvider;
        private readonly Inventory _inventory;
        private readonly Wallet _wallet;
        private readonly Dictionary<ProductId, int> _catalog;

        public Shop(Inventory inventory, ProductProvider productProvider, Wallet wallet, Dictionary<ProductId, int> catalog)
        {
            _inventory = inventory;
            _productProvider = productProvider;
            _wallet = wallet;
            _catalog = catalog;
        }

        public int GetCountOf(ProductId id)
        {
            if (_catalog.TryGetValue(id, out var count))
                return count;

            throw new Exception();
        }

        public void Buy(ProductId id)
        {
            var product = _productProvider.GetProduct(id);

            if (_catalog[id] == 0)
                return;

            var price = product.PriceProvider.GetPrice();

            if (!_wallet.TrySubtract(price))
                return;

            _catalog[id] -= 1;
            _inventory.AddItem(product.Id);
        }
    }
}