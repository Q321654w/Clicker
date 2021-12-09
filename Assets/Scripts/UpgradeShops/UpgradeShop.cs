using System.Collections.Generic;
using System.Linq;

namespace DefaultNamespace
{
    public class UpgradeShop
    {
        private readonly Dictionary<IUpgrade, Number> _catalog;

        public UpgradeShop(Dictionary<IUpgrade, Number> catalog)
        {
            _catalog = catalog;
        }
        
        public bool TryUpgrade<T>(Player player)
        {
            var upgradeNumberPair = _catalog.First(s=> s.Key is T);
            
            var upgrade = upgradeNumberPair.Key;
            var cost = upgradeNumberPair.Value;

            if (!player.TryGetPayment(cost))
                return false;
            
            upgrade.Upgrade();

            return true;
        }
    }
}