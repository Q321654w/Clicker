using System;
using System.Collections.Generic;

namespace DefaultNamespace
{
    [Serializable]
    public readonly struct InventoryData
    {
        private readonly List<string> _items;

        public InventoryData(List<string> items)
        {
            _items = items;
        }

        public List<string> Items => _items;
    }
}