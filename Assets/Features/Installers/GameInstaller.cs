using System;
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

        private void Awake()
        {
            var game = CreateGame();
            game.Start();
        }

        private Game CreateGame()
        {
            var wallet = CreateWallet();
            var inventory = CreateInventory();
            var buffFactoryFacade = CreateBuffFactoryFacade();
            var manufactureFactory = CreateManufactureFactory();

            var productFactory = CreateProductFactory(inventory);
            var productProvider = CreateProductProvider(productFactory);
            var shop = CreateShop(inventory, productProvider, wallet);

            var passiveIncomeProvider = CreateIncomeProvider();
            var passiveIncome = CreatePassiveIncome(wallet, passiveIncomeProvider);

            var mediator = CreateInventoryManufactureMediator(passiveIncomeProvider, inventory, manufactureFactory);
            var buffMediator = CreateBuffMediator(passiveIncomeProvider, buffFactoryFacade, inventory);

            var ui = _uiInstaller.Install(wallet, shop, productProvider, passiveIncomeProvider);

            var clickIncomeProvider = CreateIncomeProvider();
            var clickIncome = CreateClickIncome(wallet, _uiInstaller.ClickButton, clickIncomeProvider, manufactureFactory);

            var player = CreatePlayer(wallet, clickIncome, passiveIncome, inventory);
            var cleanUps = new List<ICleanUp>()
            {
                shop, clickIncomeProvider, passiveIncomeProvider, ui, inventory, clickIncome, mediator, buffMediator
            };

            var game = new Game(_gameUpdates, player, ui, shop, mediator, buffMediator, cleanUps);

            return game;
        }

        private InventoryBuffMediator CreateBuffMediator(IncomeProvider passiveIncomeProvider, BuffFactoryFacade buffFactoryFacade,
            Inventory inventory)
        {
            return new InventoryBuffMediator(passiveIncomeProvider, buffFactoryFacade, inventory);
        }

        private ProductFactory CreateProductFactory(Inventory inventory)
        {
            return new ProductFactory(inventory, _productDataBase);
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
            return new BuffFactoryFacade(new IBuffFactory[] {multiplierBuffFactory});
        }

        private ProductProvider CreateProductProvider(ProductFactory productFactory)
        {
            return new ProductProvider(productFactory);
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

        private PassiveIncome CreatePassiveIncome(Wallet wallet, IncomeProvider incomeProvider)
        {
            return new PassiveIncome(wallet, incomeProvider);
        }

        private Inventory CreateInventory()
        {
            return new Inventory(new List<string>());
        }

        private Wallet CreateWallet()
        {
            return new Wallet(new Number(0, 0));
        }

        private ClickIncome CreateClickIncome(Wallet wallet, CustomButton button, IncomeProvider incomeProvider, ManufactureFactory factory)
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