using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameInstaller : MonoBehaviour
    {
        [SerializeField] private MoneyProviderInstaller _moneyProviderInstaller;
        [SerializeField] private GameUpdates _gameUpdates;
        [SerializeField] private ScoreView _scoreViewPrefab;
        [SerializeField] private Canvas _canvasPrefab;
        [SerializeField] private CustomButton _clickButtonPrefab;

        private void Awake()
        {
            _moneyProviderInstaller.Install();
            Install();
        }

        private void Install()
        {
            var providerFactory = CreateMoneyProviderFactory();
            var moneyProviderShop = CreateMoneyProviderShop(providerFactory);
            var upgradeShop = CreateUpgradeShop();

            var wallet = CreateWallet();
            var ui = CreateUi(wallet, out var button);
            var clickIncome = CreateClickIncome(wallet, button);
            var player = CreatePlayer(wallet, clickIncome);

            var game = new Game(_gameUpdates, player, ui, moneyProviderShop, upgradeShop);
            game.Start();
        }

        private MoneyProviderFactory CreateMoneyProviderFactory()
        {
            var moneyProviders = _moneyProviderInstaller.MoneyProviders;
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
            var catalog = new Dictionary<int, Number>();
            var moneyProviders = new Dictionary<int, IUpgrade>();
            return new UpgradeShop(catalog, moneyProviders);
        }

        private MoneyProviderShop CreateMoneyProviderShop(MoneyProviderFactory factory)
        {
            var catalog = new Dictionary<int, Number>();
            return new MoneyProviderShop(factory, catalog);
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