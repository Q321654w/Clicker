namespace DefaultNamespace
{
    public class PassiveIncome : IGameUpdate
    {
        private readonly Wallet _wallet;
        private readonly IncomeProvider _incomeProvider;
        private float _passedTime;

        private const float INCOME_DELAY = 1f;
        
        public PassiveIncome(Wallet wallet, IncomeProvider incomeProvider)
        {
            _wallet = wallet;
            _incomeProvider = incomeProvider;
        }

        public void GameUpdate(float deltaTime)
        {
            _passedTime += deltaTime;
            if (_passedTime < INCOME_DELAY)
                return;

            _passedTime = 0;
            
            var income = _incomeProvider.Income;
            _wallet.AddMoney(income);
        }
    }
}