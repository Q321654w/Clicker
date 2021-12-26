using System;

namespace DefaultNamespace
{
    public class Player : IGameUpdate
    {
        public event Action<IGameUpdate> UpdateRemoveRequested;

        private readonly Wallet _wallet;
        private readonly Income _passiveIncome;
        private readonly ClickIncome _clickIncome;
        private readonly Inventory _inventory;

        public Player(Wallet wallet, Income passiveIncome, ClickIncome clickIncome, Inventory inventory)
        {
            _wallet = wallet;

            _passiveIncome = passiveIncome;
            _clickIncome = clickIncome;
            _inventory = inventory;
        }

        public void GameUpdate(float deltaTime)
        {
            _passiveIncome.GameUpdate(deltaTime);
        }
    }
}