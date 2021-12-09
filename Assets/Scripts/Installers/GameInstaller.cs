using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameInstaller : MonoBehaviour
    {
        [SerializeField] private GameUpdates _gameUpdates;
        [SerializeField] private ScoreView _scoreViewPrefab;
        [SerializeField] private Canvas _canvasPrefab;
        [SerializeField] private CustomButton _clickButtonPrefab;

        private void Awake()
        {
            var providerFactory = CreateMoneyProviderFactory(out var moneyProviders);
            var moneyProviderShop = CreateMoneyProviderShop(providerFactory, moneyProviders);
            var upgradeShop = CreateUpgradeShop();

            var wallet = CreateWallet();
            var ui = CreateUi(wallet, out var button);
            var clickIncome = CreateClickIncome(wallet, button);
            var player = CreatePlayer(wallet, clickIncome);

            var game = new Game(_gameUpdates, player, ui, moneyProviderShop, upgradeShop);
            game.Start();
        }

        private MoneyProviderFactory CreateMoneyProviderFactory(out IMoneyProvider[] moneyProviders)
        {
            moneyProviders = new IMoneyProvider[]
            {
                new SimpleMoneyProvider(new Number(0, 1)),
                new SimpleMoneyProvider(new Number(1, 1)),
                new SimpleMoneyProvider(new Number(2, 1)),
            };

            return new MoneyProviderFactory(moneyProviders);
        }

        private Wallet CreateWallet()
        {
            return new Wallet(new Number(0, 1));
        }

        private ClickIncome CreateClickIncome(Wallet wallet, CustomButton button)
        {
            var number = new Number(0, 1);
            var simpleMoneyProvider = new SimpleMoneyProvider(number);
            var moneyProvider = new MoneyProvider(simpleMoneyProvider);
            return new ClickIncome(wallet, button, moneyProvider);
        }

        private Ui CreateUi(Wallet wallet, out CustomButton clickButton)
        {
            var canvas = Instantiate(_canvasPrefab);
            var scoreView = Instantiate(_scoreViewPrefab, canvas.transform);
            scoreView.Initialize(wallet);

            clickButton = Instantiate(_clickButtonPrefab, canvas.transform);

            return new Ui(scoreView);
        }

        private UpgradeShop CreateUpgradeShop()
        {
            var upgrades = new Dictionary<IUpgrade, Number>()
            {
            };
            return new UpgradeShop(upgrades);
        }

        private MoneyProviderShop CreateMoneyProviderShop(MoneyProviderFactory factory, IMoneyProvider[] moneyProviders)
        {
            var products = new Dictionary<IMoneyProvider, Number>();
            return new MoneyProviderShop(factory, products);
        }

        private Player CreatePlayer(Wallet wallet, ClickIncome clickIncome)
        {
            var playerInput = new PlayerInput(KeyCode.Mouse0);
            var incomeProviders = new List<IMoneyProvider>();
            var income = new PassiveIncome(incomeProviders);
            return new Player(wallet, playerInput, income, clickIncome);
        }
    }
}