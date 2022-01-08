using System;

namespace DefaultNamespace
{
    [Serializable]
    public readonly struct WalletData
    {
        private readonly Number _money;

        public WalletData(Number money)
        {
            _money = money;
        }

        public Number Money => _money;
    }
}