using System;
using DefaultNamespace.ProductProviders;

namespace DefaultNamespace
{
    [Serializable]
    public class GameData
    {
        private InventoryData _inventory;
        private WalletData _wallet;
        private IncomeProviderData _passiveIncomeProvider;
        private IncomeProviderData _clickIncomeProvider;
        private ShopData _shop;
        private ProductProviderData _productProviderData;

        public GameData(InventoryData inventory, WalletData wallet, IncomeProviderData passiveIncomeProvider, 
            IncomeProviderData clickIncomeProvider, ShopData shop, ProductProviderData productProviderData)
        {
            _inventory = inventory;
            _wallet = wallet;
            _passiveIncomeProvider = passiveIncomeProvider;
            _clickIncomeProvider = clickIncomeProvider;
            _shop = shop;
            _productProviderData = productProviderData;
        }

        public InventoryData Inventory => _inventory;
        public WalletData Wallet => _wallet;
        public IncomeProviderData PassiveIncomeProvider => _passiveIncomeProvider;
        public IncomeProviderData ClickIncomeProvider => _clickIncomeProvider;
        public ShopData Shop => _shop;
        public ProductProviderData ProviderData => _productProviderData;
    }
}