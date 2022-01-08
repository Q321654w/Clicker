using System;
using System.Collections.Generic;

namespace DefaultNamespace
{
    public class Game
    {
        public event Action<GameData> Ended;

        private readonly GameUpdates _gameUpdates;
        private readonly Player _player;
        private readonly Ui _ui;
        private readonly Shop _shop;
        private readonly InventoryBuffMediator _buffMediator;
        private readonly InventoryManufactureMediator _manufactureMediator;

        private readonly GameDataProvider _gameDataProvider;
        private readonly IEnumerable<ICleanUp> _cleanUps;

        public Game(GameUpdates gameUpdates, Player player, Ui ui, Shop shop, InventoryManufactureMediator manufactureMediator,
            InventoryBuffMediator buffMediator, IEnumerable<ICleanUp> cleanUps, GameDataProvider gameDataProvider)
        {
            _gameUpdates = gameUpdates;
            _player = player;
            _ui = ui;
            _shop = shop;
            _buffMediator = buffMediator;
            _cleanUps = cleanUps;
            _gameDataProvider = gameDataProvider;

            _manufactureMediator = manufactureMediator;
        }

        public void Start()
        {
            _gameUpdates.AddToUpdates(_player);
            _gameUpdates.Resume();
            _ui.ShowScore();
            _ui.ShowShop();
        }

        public GameData GetData()
        {
            return _gameDataProvider.GetGameData();
        }

        public void End()
        {
            foreach (var cleanUp in _cleanUps)
            {
                cleanUp.CleanUp();
            }

            var data = _gameDataProvider.GetGameData();
            Ended?.Invoke(data);
            Ended = null;
        }
    }
}