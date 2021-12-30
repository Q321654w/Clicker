using System.Collections.Generic;
using System.Linq;

namespace DefaultNamespace
{
    public class Manufacture
    {
        private readonly string _id;
        
        private readonly Number _baseMoney;
        private readonly List<IBuff> _buffs;
        private Number _money;

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

        private void CalculateMoney()
        {
            var money = _baseMoney;

            foreach (var buff in _buffs)
            {
                money += buff.Apply(money);
            }

            _money = money;
        }

        public Number GetMoney()
        {
            return _money;
        }
    }
}