using System.Linq;

namespace DefaultNamespace
{
    public class MoneyProviderFactory 
    {
        private readonly IMoneyProvider[] _moneyProviders;

        public MoneyProviderFactory(IMoneyProvider[] moneyProviders)
        {
            _moneyProviders = moneyProviders;
        }

        public MoneyProvider Get<T>() where T : IMoneyProvider
        {
            var moneyProvider = _moneyProviders.First(s => s is T);
            return new MoneyProvider(moneyProvider);
        }
    }
}