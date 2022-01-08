using System;

namespace DefaultNamespace
{
    [Serializable]
    public class CountScalingBuff : IBuff
    {
        private readonly Inventory _inventory;
        private readonly Number _number;
        private readonly string _targetId;

        public CountScalingBuff(Inventory inventory, Number number, string targetId)
        {
            _inventory = inventory;
            _number = number;
            _targetId = targetId;
        }

        public bool CanApply(string id)
        {
            return _targetId == id;
        }

        public Number Apply(Number moneys)
        {
            var count = _inventory.GetCountOf(_targetId);
            return moneys + _number * count;
        }
    }
}