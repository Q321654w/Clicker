using System;
using System.Collections.Generic;

namespace DefaultNamespace
{
    public class Inventory
    {
        public event Action<string> ItemAdded;

        private List<string> _items;

        public Inventory(List<string> items)
        {
            _items = items;
        }

        public void AddItem(string id)
        {
            _items.Add(id);
            ItemAdded?.Invoke(id);
        }
    }
}