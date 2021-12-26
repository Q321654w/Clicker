using System.Collections.Generic;

namespace DefaultNamespace
{
    public class IncomeProvider
    {
        private readonly List<Manufacture> _moneyProviders;
        private readonly List<IBuff> _buffs;

        private Number _income;

        public IncomeProvider(List<Manufacture> moneyProviders, List<IBuff> buffs)
        {
            _moneyProviders = moneyProviders;
            _buffs = buffs;

            CalculateIncome();
        }

        public IncomeProvider(Manufacture manufacture, List<IBuff> buffs)
        {
            _buffs = buffs;

            _moneyProviders = new List<Manufacture>()
            {
                manufacture
            };

            CalculateIncome();
        }

        private void CalculateIncome()
        {
            Number income = new Number(0, 0);

            foreach (var manufacture in _moneyProviders)
            {
                Number moneys = manufacture.GetMoney();

                foreach (var buff in _buffs)
                {
                    if (buff.TryApply(manufacture.Id, moneys, out var buffedMoneys))
                    {
                        moneys += buffedMoneys;
                    }
                }

                income += moneys;
            }

            _income = income;
        }

        public Number GetIncome()
        {
            return _income;
        }

        public void AddMoneyProvider(Manufacture manufacture)
        {
            _moneyProviders.Add(manufacture);
            CalculateIncome();
        }

        public void AddBuff(IBuff buff)
        {
            _buffs.Add(buff);
            CalculateIncome();
        }
    }
}