using System;

namespace DefaultNamespace
{
    public class Player : IGameUpdate
    {
        public event Action<IGameUpdate> UpdateRemoveRequested;
        
        private readonly Wallet _wallet;
        private readonly PlayerInput _input;
        private readonly PassiveIncome _passiveIncome;
        private readonly ClickIncome _clickIncome;

        public Player(Wallet wallet, PlayerInput input, PassiveIncome passiveIncome, ClickIncome clickIncome)
        {
            _wallet = wallet;
            _input = input;
            _passiveIncome = passiveIncome;
            _clickIncome = clickIncome;
        }
        
        public void GameUpdate(float deltaTime)
        {
            _input.GameUpdate(deltaTime);
            
            var income = _passiveIncome.Get();
            _wallet.AddMoney(income);
        }

        public bool TryGetPayment(Number amount)
        {
            return _wallet.TrySubtract(amount);
        }
    }
}