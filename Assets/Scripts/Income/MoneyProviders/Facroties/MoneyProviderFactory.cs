using System;
using System.Collections.Generic;

namespace DefaultNamespace
{
    public class MoneyProviderFactory
    {
        private readonly Dictionary<int, IMoneyProvider> _moneyProviders;

        public MoneyProviderFactory(Dictionary<int, IMoneyProvider> moneyProviders)
        {
            _moneyProviders = moneyProviders;
        }

        public MoneyProvider Get(int id)
        {
            if (_moneyProviders.TryGetValue(id, out var moneyProvider))
                return new MoneyProvider(moneyProvider);
            
            throw new Exception();
        }
    }
}