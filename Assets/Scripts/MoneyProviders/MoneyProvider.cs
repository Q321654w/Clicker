using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(menuName = "MoneyProvider")]
    public class MoneyProvider : ScriptableObject
    {
        [SerializeField] private Number _number;
        [SerializeField] private string _moneyProviderId;
        
        public string ProviderId => _moneyProviderId;

        public Number GetMoney()
        {
           return _number;
        }
    }
}