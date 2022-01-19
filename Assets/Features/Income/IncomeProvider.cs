using System;
using System.Collections.Generic;
using System.Linq;

namespace DefaultNamespace
{
    public class IncomeProvider : ICleanUp
    {
        public event Action<Number> IncomeChanged;

        private readonly List<Manufacture> _manufactures;
        private readonly List<IBuff> _buffs;

        public Number Income { get; private set; }

        public IncomeProvider(IEnumerable<Manufacture> manufactures)
        {
            _manufactures = manufactures.ToList();
            _buffs = new List<IBuff>();
            CalculateIncome();
        }
        
        public IncomeProvider(IEnumerable<Manufacture> manufactures, IEnumerable<IBuff> buffs)
        {
            _manufactures = manufactures.ToList();
            _buffs = buffs.ToList();
            CalculateIncome();
        }
        
        public void AddManufacture(Manufacture manufacture)
        {
            _manufactures.Add(manufacture);
            CalculateIncome();
        }

        public void AddBuff(IBuff buff)
        {
            _buffs.Add(buff);
            CalculateIncome();
        }

        public void RemoveManufacture(Manufacture manufacture)
        {
            _manufactures.Remove(manufacture);
            CalculateIncome();
        }

        public void RemoveBuff(IBuff buff)
        {
            _buffs.Remove(buff);
            CalculateIncome();
        }

        private void CalculateIncome()
        {
            var income = new Number(0, 0);

            foreach (var manufacture in _manufactures)
            {
                var money = manufacture.GetMoney();

                foreach (var buff in _buffs)
                {
                    if (buff.CanApply(manufacture.Id))
                    {
                        money += buff.Apply(money);
                    }
                }

                income += money;
            }

            Income = income;
            IncomeChanged?.Invoke(Income);
        }

        public void CleanUp()
        {
            IncomeChanged = null;
        }
    }
}