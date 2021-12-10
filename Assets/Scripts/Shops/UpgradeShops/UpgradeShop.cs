using System;
using System.Collections.Generic;

namespace DefaultNamespace
{
    public class UpgradeShop
    {
        private readonly Dictionary<int, Number> _catalog;
        private readonly Dictionary<int, IUpgrade> _moneyProviders;

        public UpgradeShop(Dictionary<int, Number> catalog, Dictionary<int, IUpgrade> moneyProviders)
        {
            _catalog = catalog;
            _moneyProviders = moneyProviders;
        }

        public bool TryUpgrade(int id, Player player)
        {
            if (!_catalog.TryGetValue(id, out var cost))
                throw new Exception();

            if (!player.TryGetPayment(cost))
                return false;

            if (!_moneyProviders.TryGetValue(id, out var upgrade))
                throw new Exception();
            
            upgrade.Upgrade();

            return true;
        }
    }
}