using System.Collections.Generic;

namespace DefaultNamespace
{
    public class Shop
    {
        private readonly ProductDataBase _dataBase;
        private readonly Inventory _inventory;
        private readonly Wallet _wallet;
        private readonly Dictionary<ProductId, int> _catalog;

        public Shop(Inventory inventory, ProductDataBase dataBase, Wallet wallet)
        {
            _inventory = inventory;
            _dataBase = dataBase;
            _wallet = wallet;

            _catalog = new Dictionary<ProductId, int>();
            foreach (var product in _dataBase.Products)
            {
                _catalog.Add(product.ProductId, product.Count);
            }
        }

        public void Buy(ProductId id)
        {
            var product = _dataBase.GetProduct(id);

            if (_catalog[id] == 0)
                return;

            var price = product.Price;

            if (!_wallet.TrySubtract(price))
                return;
            
            _catalog[id] -= 1;
            _inventory.AddItem(product.Id);
        }
    }
}