using System.Collections.Generic;
using System.Linq;

namespace DefaultNamespace
{
    public class Manufacture
    {
        private readonly Number _baseMoney;
        private Number _money;
        private List<IBuff> _buffs;
        private string _id;

        public string Id => _id;

        public Manufacture(Number baseMoney, string id, IEnumerable<IBuff> buffs)
        {
            _baseMoney = baseMoney;
            _id = id;
            _buffs = buffs.ToList();
            CalculateMoney();
        }

        public Manufacture(Number baseMoney, string id)
        {
            _baseMoney = baseMoney;
            _money = _baseMoney;
            _id = id;
            _buffs = new List<IBuff>();
        }

        public void AddBuff(IBuff buff)
        {
            _buffs.Add(buff);
            CalculateMoney();
        }

        private void CalculateMoney()
        {
            var money = _baseMoney;

            foreach (var buff in _buffs)
            {
                money += buff.Apply(money);
            }

            _money = money;
        }

        public void RemoveBuff(IBuff buff)
        {
            _buffs.Remove(buff);
            CalculateMoney();
        }

        public Number GetMoney()
        {
            return _money;
        }
    }
}