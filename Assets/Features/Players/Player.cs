namespace DefaultNamespace
{
    public class Player : IGameUpdate
    {
        private readonly Wallet _wallet;
        private readonly PassiveIncome _passivePassiveIncome;
        private readonly ClickIncome _clickIncome;
        private readonly Inventory _inventory;

        public Player(Wallet wallet, PassiveIncome passivePassiveIncome, ClickIncome clickIncome, Inventory inventory)
        {
            _wallet = wallet;
            _passivePassiveIncome = passivePassiveIncome;
            _clickIncome = clickIncome;
            _inventory = inventory;
        }

        public void GameUpdate(float deltaTime)
        {
            _passivePassiveIncome.GameUpdate(deltaTime);
        }
    }
}