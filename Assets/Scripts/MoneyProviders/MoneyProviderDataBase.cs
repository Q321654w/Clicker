using System.Linq;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(menuName = "MoneyProviderDataBase")]
    public class MoneyProviderDataBase : ScriptableObject
    {
        [SerializeField] private MoneyProvider[] _moneyProviders;
        
        public MoneyProvider GetMoneyProvider(string id)
        {
            return _moneyProviders.Single(s => s.ProviderId == id);
        }
    }
}