namespace DefaultNamespace
{
    public class Game
    {
        private GameUpdates _gameUpdates;
        private Player _player;
        private Ui _ui;
        private MoneyProviderShop _moneyProviderShop;
        private UpgradeShop _upgradeShop;
        
        public Game(GameUpdates gameUpdates, Player player, Ui ui, MoneyProviderShop moneyProviderShop, UpgradeShop upgradeShop)
        {
            _gameUpdates = gameUpdates;
            _player = player;
            _ui = ui;
            _moneyProviderShop = moneyProviderShop;
            _upgradeShop = upgradeShop;
        }
        
        public void Start()
        {
            _gameUpdates.AddToUpdates(_player);
            _gameUpdates.Resume();
            _ui.ShowScore();
        }
    }
}