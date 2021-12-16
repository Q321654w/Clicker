using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(menuName = "MoneyProviderConfig")]
    public class MoneyProviderConfig : ScriptableObject
    {
        [SerializeField] private Number _number;
        [SerializeField] private string _id;

        public Number Number => _number;
        public string Id => _id;
    }
}