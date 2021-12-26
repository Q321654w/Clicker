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
        [SerializeField] private ManufactureDataBase _providerDataBase;
        [SerializeField] private string _clickMoneyProviderId;

        private void Awake()
        {
            Install();
        }

        private void Install()
        {
            var wallet = CreateWallet();
            var inventory = CreateInventory();

            var multiplierBuffFactory = new MultiplyBuffFactory("Manufacture");
            var buffFactory = new BuffFactoryFacade(new IBuffFactory[] {multiplierBuffFactory});
            var moneyProviderFactory = new ManufactureFactory(_providerDataBase);
            var productFactory = new ProductFactory(inventory, _productDataBase);
            var productProvider = CreateProductProvider(productFactory);
            var shop = CreateShop(inventory, productProvider, wallet);

            var ui = _uiInstaller.Install(wallet, shop, productProvider);

            var clickIncome = CreateClickIncome(wallet, moneyProviderFactory, _uiInstaller.ClickButton);
            var passiveIncome = CreatePassiveIncome(wallet, inventory, moneyProviderFactory, buffFactory, out var mediator,
                out var buffMediator);
            var player = CreatePlayer(wallet, clickIncome, passiveIncome, inventory);

            var game = new Game(_gameUpdates, player, ui, shop, mediator);
            game.Start();
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

        private Income CreatePassiveIncome(Wallet wallet, Inventory inventory, ManufactureFactory factory,
            BuffFactoryFacade buffFactoryFacade,
            out InventoryManufactureMediator inventoryManufactureMediator, out InventoryBuffMediator inventoryBuffMediator)
        {
            var incomeProvider = new IncomeProvider(new List<Manufacture>(),
                new List<IBuff>());

            inventoryBuffMediator = new InventoryBuffMediator(incomeProvider, buffFactoryFacade, inventory);
            inventoryManufactureMediator = new InventoryManufactureMediator(incomeProvider, inventory, factory);
            return new Income(wallet, incomeProvider);
        }

        private Inventory CreateInventory()
        {
            return new Inventory(new List<string>());
        }

        private Wallet CreateWallet()
        {
            return new Wallet();
        }

        private ClickIncome CreateClickIncome(Wallet wallet, ManufactureFactory factory, CustomButton button)
        {
            var moneyProvider = factory.Create(_clickMoneyProviderId);
            var incomeProvider = new IncomeProvider(moneyProvider, new List<IBuff>());
            return new ClickIncome(wallet, button, incomeProvider);
        }

        private Player CreatePlayer(Wallet wallet, ClickIncome clickIncome, Income passiveIncome, Inventory inventory)
        {
            return new Player(wallet, passiveIncome, clickIncome, inventory);
        }
    }
}