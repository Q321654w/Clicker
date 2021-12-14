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
        [SerializeField] private MoneyProviderFactory _moneyProviderFactory;
        [SerializeField] private Product[] _catalog;
        [SerializeField] private NumberFormatter _numberFormatter;

        private void Awake()
        {
            Install();
        }

        private void Install()
        {
            var shop = new Shop(_moneyProviderFactory, _catalog);

            var wallet = CreateWallet();
            var ui = CreateUi(wallet, out var button);
            var clickIncome = CreateClickIncome(wallet, button);
            var player = CreatePlayer(wallet, clickIncome, shop);

            var game = new Game(_gameUpdates, player, ui, shop);
            game.Start();
        }

        private Wallet CreateWallet()
        {
            return new Wallet();
        }

        private ClickIncome CreateClickIncome(Wallet wallet, CustomButton button)
        {
            var number = new Number(1, 2);
            var simpleMoneyProvider = new MoneyProvider(number);
            var incomeProvider = new IncomeProvider(simpleMoneyProvider);
            return new ClickIncome(wallet, button, incomeProvider);
        }

        private Ui CreateUi(Wallet wallet, out CustomButton clickButton)
        {
            var canvas = Instantiate(_canvasPrefab);
            var scoreView = Instantiate(_scoreViewPrefab, canvas.transform);
            scoreView.Initialize(wallet, _numberFormatter);

            clickButton = Instantiate(_clickButtonPrefab, canvas.transform);

            return new Ui(scoreView);
        }

        private Player CreatePlayer(Wallet wallet, ClickIncome clickIncome, Shop shop)
        {
            var playerInput = new PlayerInput(KeyCode.Mouse0);
            var moneyProviders = new List<MoneyProvider>()
            {
                new MoneyProvider(new Number(0, 1))
            };
            var incomeProvider = new IncomeProvider(moneyProviders);
            var income = new Income(wallet, incomeProvider);
            return new Player(wallet, playerInput, income, clickIncome, shop);
        }
    }
}