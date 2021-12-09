using System.Collections.Generic;
using System.Linq;

namespace DefaultNamespace
{
    public class MoneyProviderShop
    {
        private readonly MoneyProviderFactory _factory;
        private readonly Dictionary<IMoneyProvider, Number> _catalog;

        private const float SELL_COEFFICIENT = 0.75f;

        public MoneyProviderShop(MoneyProviderFactory factory, Dictionary<IMoneyProvider, Number> catalog)
        {
            _factory = factory;
            _catalog = catalog;
        }

        public bool TryBuy<T>(Player player, out MoneyProvider moneyProvider) where T : IMoneyProvider
        {
            moneyProvider = null;

            var pair = _catalog.First(s => s.Key is T);
            var cost = pair.Value;

            if (!player.TryGetPayment(cost)) return false;

            moneyProvider = _factory.Get<T>();
            return true;
        }

        public Number Sell(IMoneyProvider moneyProvider)
        {
            var pair = _catalog.TryGetValue(moneyProvider, out var cost);
            return cost * SELL_COEFFICIENT;
        }
    }
}