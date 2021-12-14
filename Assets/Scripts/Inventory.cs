using System;
using System.Collections.Generic;

namespace DefaultNamespace
{
    public class Inventory
    {
        public event Action<MoneyProviderId> ItemAdded;
        
        public List<MoneyProviderId> Items;
    }

}