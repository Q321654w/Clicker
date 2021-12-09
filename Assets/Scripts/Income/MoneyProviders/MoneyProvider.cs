namespace DefaultNamespace
{
    public class MoneyProvider
    {
        private readonly IMoneyProvider _moneyProvider;

        public MoneyProvider(IMoneyProvider moneyProvider)
        {
            _moneyProvider = moneyProvider;
        }

        public Number GetMoney()
        {
            return _moneyProvider.GetMoney();
        }
    }
}