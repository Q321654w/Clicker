using System;
using System.Collections.Generic;

namespace DefaultNamespace
{
    public class Inventory : ICleanUp
    {
        public event Action<string> ItemAdded;

        private readonly List<string> _items;

        public Inventory(List<string> items)
        {
            _items = items;
        }

        public void AddItem(string id)
        {
            _items.Add(id);
            ItemAdded?.Invoke(id);
        }

        public int GetCountOf(string id)
        {
            var count = 0;

            foreach (var item in _items)
            {
                if (item == id)
                    count++;
            }

            return count;
        }

        public void CleanUp()
        {
            ItemAdded = null;
        }
    }
}