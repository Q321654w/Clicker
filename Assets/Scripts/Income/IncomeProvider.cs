using System.Collections.Generic;

namespace DefaultNamespace
{
    public class IncomeProvider
    {
        private readonly List<Manufacture> _manufactures;
        private readonly List<IBuff> _buffs;

        private Number _income;

        public IncomeProvider(List<Manufacture> manufactures)
        {
            _manufactures = manufactures;
            _buffs = new List<IBuff>();
            CalculateIncome();
        }
        
        public IncomeProvider(List<Manufacture> manufactures, List<IBuff> buffs)
        {
            _manufactures = manufactures;
            _buffs = buffs;
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

            _income = income;
        }

        public Number GetIncome()
        {
            return _income;
        }
    }
}