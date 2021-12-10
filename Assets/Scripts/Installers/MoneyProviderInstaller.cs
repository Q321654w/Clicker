using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class MoneyProviderInstaller : MonoBehaviour
    {
        public Dictionary<int, IMoneyProvider> MoneyProviders { get; private set; }
        
        public void Install()
        {
            MoneyProviders = new Dictionary<int, IMoneyProvider>()
            {
                {1, new SimpleMoneyProvider(new Number(0, 1))},
                {2, new SimpleMoneyProvider(new Number(1, 1))},
                {3, new UpgradableMoneyProvider(new Number(1,1),1)}
            };
        }
    }
}