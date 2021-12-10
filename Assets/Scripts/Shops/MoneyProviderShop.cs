using System;
using System.Collections.Generic;

namespace DefaultNamespace
{
    public class MoneyProviderShop
    {
        private readonly MoneyProviderFactory _factory;
        private readonly Dictionary<int, Number> _catalog;

        private const float SELL_COEFFICIENT = 0.75f;

        public MoneyProviderShop(MoneyProviderFactory factory, Dictionary<int, Number> catalog)
        {
            _factory = factory;
            _catalog = catalog;
        }

        public bool TryBuy(int id, Player player, out MoneyProvider moneyProvider)
        {
            moneyProvider = null;

            if (!_catalog.TryGetValue(id, out var value))
                throw new Exception();
            
            var cost = value;

            if (!player.TryGetPayment(cost)) 
                return false;

            moneyProvider = _factory.Get(id);
            return true;
        }

        public Number Sell(int id)
        {
            var pair = _catalog.TryGetValue(id, out var cost);
            return cost * SELL_COEFFICIENT;
        }
    }
}