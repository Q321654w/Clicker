using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameInstaller : MonoBehaviour
    {
        [SerializeField] private UiInstaller _uiInstaller;
        [SerializeField] private GameUpdates _gameUpdates;

        [SerializeField] private ProductDataBase _productDataBase;
        [SerializeField] private MoneyProviderDataBase _providerDataBase;
        [SerializeField] private string _clickMoneyProviderId;

        private void Awake()
        {
            Install();
        }

        private void Install()
        {
            var wallet = CreateWallet();
            var inventory = CreateInventory();
            
            var shop = new Shop(inventory, _productDataBase, wallet);

            var ui = _uiInstaller.Install(wallet, shop, _productDataBase);
            
            var clickIncome = CreateClickIncome(wallet, _uiInstaller.ClickButton);
            var passiveIncome = CreatePassiveIncome(wallet, inventory, out var mediator);
            var player = CreatePlayer(wallet, clickIncome, passiveIncome, inventory);

            var game = new Game(_gameUpdates, player, ui, shop, mediator);
            game.Start();
        }

        private Income CreatePassiveIncome(Wallet wallet, Inventory inventory, out InventoryIncomeProviderMediator mediator)
        {
            var incomeProvider = new IncomeProvider(new List<MoneyProvider>());
            mediator = new InventoryIncomeProviderMediator(incomeProvider, inventory, _providerDataBase);
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

        private ClickIncome CreateClickIncome(Wallet wallet, CustomButton button)
        {
            var moneyProvider = _providerDataBase.GetMoneyProvider(_clickMoneyProviderId);
            var incomeProvider = new IncomeProvider(moneyProvider);
            return new ClickIncome(wallet, button, incomeProvider);
        }

        private Player CreatePlayer(Wallet wallet, ClickIncome clickIncome, Income passiveIncome, Inventory inventory)
        {
            var playerInput = new PlayerInput(KeyCode.Mouse0);
            return new Player(wallet, playerInput, passiveIncome, clickIncome, inventory);
        }
    }
}