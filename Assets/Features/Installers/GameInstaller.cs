using System.Collections.Generic;
using DefaultNamespace.ProductProviders;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameInstaller : MonoBehaviour
    {
        [SerializeField] private UiInstaller _uiInstaller;
        [SerializeField] private GameUpdates _gameUpdates;

        [SerializeField] private ProductDataBase _productDataBase;
        [SerializeField] private ManufactureDataBase _manufactureDataBase;
        [SerializeField] private MultiplyBuffConfig[] _multiplyBuffConfigs;
        [SerializeField] private string _clickMoneyProviderId;
        [SerializeField] private string _multiplyIdContext;
        [SerializeField] private string _manufactureIdContext;

        private Game _game;

        [ContextMenu("SaveGame")]
        public void SaveGame()
        {
            var data = _game.GetData();
            var saveSystem = new BinarySaveSystem();
            saveSystem.Save(data);
        }

        public Game StartNew()
        {
            var inventoryData = new InventoryData(new List<string>());
            var walletData = new WalletData(new Number(0, 0));
            var passiveIncomeData = new IncomeProviderData(new List<Manufacture>(), new List<IBuff>());
            var clickIncomeData = new IncomeProviderData(new List<Manufacture>(), new List<IBuff>());
            var shopData = new ShopData(_productDataBase);
            var productProviderData = new ProductProviderData(new List<ProductData>());
            var defaultData = new GameData(inventoryData, walletData, passiveIncomeData, clickIncomeData, shopData, productProviderData);
            return CreateGame(defaultData);
        }

        public Game CreateGame(GameData data)
        {
            var wallet = CreateWallet(data.Wallet);
            var inventory = CreateInventory(data.Inventory);
            var buffFactoryFacade = CreateBuffFactoryFacade();
            var manufactureFactory = CreateManufactureFactory();

            var productFactory = CreateProductFactory(inventory);
            var productProvider = CreateProductProvider(productFactory, data.ProviderData);
            var shop = CreateShop(inventory, productProvider, wallet, data.Shop);

            var passiveIncomeProvider = CreateIncomeProvider(data.PassiveIncomeProvider);
            var passiveIncome = CreatePassiveIncome(passiveIncomeProvider, wallet);

            var mediator = CreateInventoryManufactureMediator(passiveIncomeProvider, inventory, manufactureFactory);
            var buffMediator = CreateBuffMediator(passiveIncomeProvider, buffFactoryFacade, inventory);

            var ui = _uiInstaller.Install(wallet, shop, productProvider, passiveIncomeProvider);

            var clickIncomeProvider = CreateIncomeProvider(data.ClickIncomeProvider);
            var clickIncome = CreateClickIncome(clickIncomeProvider, wallet, manufactureFactory, _uiInstaller.ClickButton);

            var player = CreatePlayer(wallet, clickIncome, passiveIncome, inventory);
            var cleanUps = new List<ICleanUp>()
            {
                shop, clickIncomeProvider, passiveIncomeProvider, ui, inventory
            };

            var saveService = new GameDataProvider(passiveIncomeProvider, clickIncomeProvider, wallet, shop, inventory, productProvider);

            _game = new Game(_gameUpdates, player, ui, shop, mediator, buffMediator, cleanUps, saveService);

            return _game;
        }

        private InventoryBuffMediator CreateBuffMediator(IncomeProvider incomeProvider, BuffFactoryFacade buffFactoryFacade,
            Inventory inventory)
        {
            return new InventoryBuffMediator(incomeProvider, buffFactoryFacade, inventory);
        }

        private InventoryManufactureMediator CreateInventoryManufactureMediator(IncomeProvider incomeProvider, Inventory inventory,
            ManufactureFactory factory)
        {
            return new InventoryManufactureMediator(incomeProvider, inventory, factory);
        }

        private IncomeProvider CreateIncomeProvider(IncomeProviderData data)
        {
            return new IncomeProvider(data);
        }

        private ManufactureFactory CreateManufactureFactory()
        {
            return new ManufactureFactory(_manufactureIdContext, _manufactureDataBase);
        }

        private BuffFactoryFacade CreateBuffFactoryFacade()
        {
            var multiplierBuffFactory = new MultiplyBuffFactory(_multiplyIdContext, _multiplyBuffConfigs);
            return new BuffFactoryFacade(new IBuffFactory[] {multiplierBuffFactory});
        }

        private ProductFactory CreateProductFactory(Inventory inventory)
        {
            return new ProductFactory(inventory, _productDataBase);
        }

        private ProductProvider CreateProductProvider(ProductFactory productFactory, ProductProviderData providerData)
        {
            var products = providerData.ProductDatas;
            
            if (products.Count == 0)
            {
                return new ProductProvider(productFactory);
            }

            return new ProductProvider(productFactory, providerData);
        }

        private Shop CreateShop(Inventory inventory, ProductProvider productProvider, Wallet wallet, ShopData shopData)
        {
            var catalog = shopData.Catalog;
            return new Shop(inventory, productProvider, wallet, catalog);
        }

        private PassiveIncome CreatePassiveIncome(IncomeProvider incomeProvider, Wallet wallet)
        {
            return new PassiveIncome(wallet, incomeProvider);
        }

        private Inventory CreateInventory(InventoryData inventoryData)
        {
            return new Inventory(inventoryData.Items);
        }

        private Wallet CreateWallet(WalletData walletData)
        {
            return new Wallet(walletData.Money);
        }

        private ClickIncome CreateClickIncome(IncomeProvider incomeProvider, Wallet wallet, ManufactureFactory factory,
            CustomButton button)
        {
            if (incomeProvider.Income <= new Number(0,0))
            {
                var manufacture = factory.Create(_clickMoneyProviderId);
                incomeProvider.AddManufacture(manufacture);
            }

            return new ClickIncome(wallet, button, incomeProvider);
        }

        private Player CreatePlayer(Wallet wallet, ClickIncome clickIncome, PassiveIncome passivePassiveIncome, Inventory inventory)
        {
            return new Player(wallet, passivePassiveIncome, clickIncome, inventory);
        }
    }
}