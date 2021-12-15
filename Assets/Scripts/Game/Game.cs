namespace DefaultNamespace
{
    public class Game
    {
        private GameUpdates _gameUpdates;
        private Player _player;
        private Ui _ui;
        private Shop _shop;

        public Game(GameUpdates gameUpdates, Player player, Ui ui, Shop shop, InventoryIncomeProviderMediator mediator)
        {
            _gameUpdates = gameUpdates;
            _player = player;
            _ui = ui;
            _shop = shop;
        }
        
        public void Start()
        {
            _gameUpdates.AddToUpdates(_player);
            _gameUpdates.Resume();
            _ui.ShowScore();
        }
    }
}