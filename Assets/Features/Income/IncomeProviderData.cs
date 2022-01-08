using System;
using System.Collections.Generic;

namespace DefaultNamespace
{
    [Serializable]
    public readonly struct IncomeProviderData
    {
        private readonly List<Manufacture> _manufactures;
        private readonly List<IBuff> _buffs;

        public IncomeProviderData(List<Manufacture> manufactures, List<IBuff> buffs)
        {
            _manufactures = manufactures;
            _buffs = buffs;
        }

        public List<Manufacture> Manufactures => _manufactures;
        public List<IBuff> Buffs => _buffs;
    }
}