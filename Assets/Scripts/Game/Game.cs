namespace DefaultNamespace
{
    public class Game
    {
        private GameUpdates _gameUpdates;
        private Player _player;
        private Ui _ui;
        private Shop _shop;
        private InventoryBuffMediator _buffMediator;
        private InventoryManufactureMediator _manufactureMediator;

        public Game(GameUpdates gameUpdates, Player player, Ui ui, Shop shop, InventoryManufactureMediator manufactureMediator,
            InventoryBuffMediator buffMediator)
        {
            _gameUpdates = gameUpdates;
            _player = player;
            _ui = ui;
            _shop = shop;
            _buffMediator = buffMediator;
            _manufactureMediator = manufactureMediator;
        }

        public void Start()
        {
            _gameUpdates.AddToUpdates(_player);
            _gameUpdates.Resume();
            _ui.ShowScore();
        }
    }
}