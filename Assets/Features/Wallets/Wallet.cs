using System;

namespace DefaultNamespace
{
    public class Wallet
    {
        public event Action<Number> MoneyCountChanged;

        public Number Money { get; private set; }

        public Wallet(Number money)
        {
            Money = money;
        }

        public void AddMoney(Number number)
        {
            Money += number;
            MoneyCountChanged?.Invoke(Money);
        }

        public bool TrySubtract(Number number)
        {
            if (number > Money)
                return false;

            Money -= number;
            MoneyCountChanged?.Invoke(Money);

            return true;
        }
    }
}