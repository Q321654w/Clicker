using System.Linq;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(menuName = "MoneyProviderDataBase")]
    public class MoneyProviderDataBase : ScriptableObject
    {
        [SerializeField] private MoneyProviderConfig[] _moneyProviders;
        
        public MoneyProviderConfig GetMoneyProvider(string id)
        {
            return _moneyProviders.Single(s => s.Id == id);
        }
    }
}