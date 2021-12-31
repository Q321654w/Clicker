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
        [SerializeField] private string _clickMoneyProviderId;
        [SerializeField] private MultiplyBuffConfig[] _multiplyBuffConfigs;
        [SerializeField] private string _buffIdContext;
        [SerializeField] private string _multiplyIdContext;
        [SerializeField] private string _manufactureIdContext;

        private void Awake()
        {
            Install();
        }

        private void Install()
        {
            var wallet = CreateWallet();
            var inventory = CreateInventory();

            var buffFactoryFacade = CreateBuffFactoryFacade();
            var manufactureFactory = CreateManufactureFactory();
            
            var productFactory = CreateProductFactory(inventory);
            var productProvider = CreateProductProvider(productFactory);
            var shop = CreateShop(inventory, productProvider, wallet);
            
            var passiveIncomeProvider = CreateIncomeProvider();
            var passiveIncome = CreatePassiveIncome(passiveIncomeProvider, wallet);
            
            var mediator = CreateInventoryManufactureMediator(passiveIncomeProvider, inventory, manufactureFactory);
            var buffMediator = CreateBuffMediator(passiveIncomeProvider, buffFactoryFacade, inventory);

            var ui = _uiInstaller.Install(wallet, shop, productProvider, passiveIncomeProvider);

            var clickIncomeProvider = CreateIncomeProvider();
            var clickIncome = CreateClickIncome(clickIncomeProvider, wallet, manufactureFactory, _uiInstaller.ClickButton);
            
            var player = CreatePlayer(wallet, clickIncome, passiveIncome, inventory);
            
            var game = new Game(_gameUpdates, player, ui, shop, mediator, buffMediator);
            game.Start();
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

        private IncomeProvider CreateIncomeProvider()
        {
            return new IncomeProvider(new List<Manufacture>());
        }

        private ManufactureFactory CreateManufactureFactory()
        {
            return new ManufactureFactory(_manufactureIdContext, _manufactureDataBase);
        }

        private BuffFactoryFacade CreateBuffFactoryFacade()
        {
            var multiplierBuffFactory = new MultiplyBuffFactory(_multiplyIdContext, _multiplyBuffConfigs);
            return new BuffFactoryFacade(new IBuffFactory[] {multiplierBuffFactory}, _buffIdContext);
        }

        private ProductFactory CreateProductFactory(Inventory inventory)
        {
            return new ProductFactory(inventory, _productDataBase);
        }

        private ProductProvider CreateProductProvider(ProductFactory productFactory)
        {
            var products = productFactory.CreateAll();
            return new ProductProvider(productFactory, products);
        }

        private Shop CreateShop(Inventory inventory, ProductProvider productProvider, Wallet wallet)
        {
            var catalog = new Dictionary<ProductId, int>();

            foreach (var config in _productDataBase.ProductConfigs)
            {
                catalog.Add(config.ProductId, config.BaseCount);
            }

            return new Shop(inventory, productProvider, wallet, catalog);
        }

        private PassiveIncome CreatePassiveIncome(IncomeProvider incomeProvider, Wallet wallet)
        {
            return new PassiveIncome(wallet, incomeProvider);
        }

        private Inventory CreateInventory()
        {
            return new Inventory(new List<string>());
        }

        private Wallet CreateWallet()
        {
            return new Wallet();
        }

        private ClickIncome CreateClickIncome(IncomeProvider incomeProvider, Wallet wallet, ManufactureFactory factory,
            CustomButton button)
        {
            var manufacture = factory.Create(_clickMoneyProviderId);
            incomeProvider.AddManufacture(manufacture);
            return new ClickIncome(wallet, button, incomeProvider);
        }

        private Player CreatePlayer(Wallet wallet, ClickIncome clickIncome, PassiveIncome passivePassiveIncome, Inventory inventory)
        {
            return new Player(wallet, passivePassiveIncome, clickIncome, inventory);
        }
    }
}