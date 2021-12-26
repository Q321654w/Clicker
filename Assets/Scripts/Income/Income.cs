using System;

namespace DefaultNamespace
{
    public class Income : IGameUpdate
    {
        public event Action<IGameUpdate> UpdateRemoveRequested;

        private readonly Wallet _wallet;
        private readonly IncomeProvider _incomeProvider;
        private float _incomeDelay = 1f;
        private float _passedTime;

        public Income(Wallet wallet, IncomeProvider incomeProvider)
        {
            _wallet = wallet;
            _incomeProvider = incomeProvider;
        }

        public void GameUpdate(float deltaTime)
        {
            _passedTime += deltaTime;
            if (_passedTime < _incomeDelay)
                return;

            _passedTime = 0;
            var income = _incomeProvider.GetIncome();
            _wallet.AddMoney(income);
        }
    }
}