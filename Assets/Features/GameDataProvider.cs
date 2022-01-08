using DefaultNamespace.ProductProviders;

namespace DefaultNamespace
{
    public class GameDataProvider
    {
        private readonly IncomeProvider _passiveIncomeProvider;
        private readonly IncomeProvider _clickIncomeProvider;
        private readonly Wallet _wallet;
        private readonly Shop _shop;
        private readonly Inventory _inventory;
        private readonly ProductProvider _productProvider;

        public GameDataProvider(IncomeProvider passiveIncomeProvider, IncomeProvider clickIncomeProvider, Wallet wallet, Shop shop,
            Inventory inventory, ProductProvider productProvider)
        {
            _passiveIncomeProvider = passiveIncomeProvider;
            _clickIncomeProvider = clickIncomeProvider;
            _wallet = wallet;
            _shop = shop;
            _inventory = inventory;
            _productProvider = productProvider;
        }

        public GameData GetGameData()
        {
            var productProviderData = _productProvider.GetData();
            var passiveIncomeData = _passiveIncomeProvider.GetData();
            var clickIncomeData = _clickIncomeProvider.GetData();
            var inventoryData = _inventory.GetData();
            var walletData = _wallet.GetData();
            var shopData = _shop.GetData();
            
            return new GameData(inventoryData, walletData, passiveIncomeData, clickIncomeData, shopData, productProviderData);
        }
    }
}