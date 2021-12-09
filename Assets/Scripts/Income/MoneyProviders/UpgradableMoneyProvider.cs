using System;

namespace DefaultNamespace
{
    public class UpgradableMoneyProvider : IMoneyProvider, IUpgrade
    {
        public event Action<int> Upgraded;

        private int _multiplier;

        private readonly Number _money;

        public UpgradableMoneyProvider(Number money, int multiplier)
        {
            _money = money;
            _multiplier = multiplier;
        }

        public Number GetMoney()
        {
            return _money * _multiplier;
        }

        void IUpgrade.Upgrade()
        {
            _multiplier++;
        }
    }
}