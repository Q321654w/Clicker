using System.Collections.Generic;

namespace DefaultNamespace
{
    public class IncomeProvider
    {
        private readonly List<MoneyProvider> _moneyProviders;

        private Number _income;

        public IncomeProvider(List<MoneyProvider> moneyProviders)
        {
            _moneyProviders = moneyProviders;

            CalculateIncome();
        }

        public IncomeProvider(MoneyProvider moneyProvider)
        {
            _moneyProviders = new List<MoneyProvider>()
            {
                moneyProvider
            };

            CalculateIncome();
        }

        private void CalculateIncome()
        {
            Number number = new Number(0, 0);

            foreach (var moneyProvider in _moneyProviders)
            {
                number += moneyProvider.GetMoney();
            }

            _income = number;
        }

        private void CalculateIncome(MoneyProvider moneyProvider)
        {
            _income += moneyProvider.GetMoney();
        }

        public Number GetIncome()
        {
            return _income;
        }

        public void AddMoneyProvider(MoneyProvider moneyProvider)
        {
            _moneyProviders.Add(moneyProvider);
            CalculateIncome(moneyProvider);
        }
    }
}