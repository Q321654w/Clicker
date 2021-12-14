using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(menuName = "MoneyProvider")]
    public class MoneyProvider : ScriptableObject
    {
        [SerializeField] private Number _number;
        [SerializeField] private MoneyProviderId _moneyProviderId;
        
        public MoneyProviderId ProviderId => _moneyProviderId;

        public Number GetMoney()
        {
           return _number;
        }
    }
}