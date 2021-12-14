using System.Collections.Generic;

namespace DefaultNamespace
{
    public class Shop
    {
        private readonly ProductDataBase _dataBase;
        private readonly Inventory _inventory;
        private Dictionary<ProductId, int> _catalog;

        public Shop(Inventory inventory, ProductDataBase dataBase)
        {
            _inventory = inventory;
            _dataBase = dataBase;

            _catalog = new Dictionary<ProductId, int>();
            foreach (var product in _dataBase.Products)
            {
                _catalog.Add(product.Id, product.Count);
            }
        }

        public void Buy(ProductId id, Wallet wallet)
        {
            var product = _dataBase.GetProduct(id);
            
            if (_catalog[id] == 0)
                return;
            
            var price = product.Price;
                
            if (!wallet.TrySubtract(price))
                return;
            
            _catalog[id] -= 1; 
            _inventory.Items.Add(new MoneyProviderId(product.ProviderId));
        }
    }
}