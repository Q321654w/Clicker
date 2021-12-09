using System.Collections.Generic;

namespace DefaultNamespace
{
    public class PassiveIncome
    {
        private List<IMoneyProvider> _moneyProviders;

        private Number _income;

        public PassiveIncome(List<IMoneyProvider> moneyProviders)
        {
            _moneyProviders = moneyProviders;

            CalculateIncome();
        }

        public void CalculateIncome()
        {
            Number number = new Number(0,0);
            
            foreach (var moneyProvider in _moneyProviders)
            {
                number += moneyProvider.GetMoney();
            }

            _income = number;
        }

        public void AddMoneyProvider(IMoneyProvider moneyProvider)
        {
            _moneyProviders.Add(moneyProvider);
            CalculateIncome();
        }

        public Number Get()
        {
            return _income;
        }
    }
}