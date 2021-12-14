using System.Linq;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(menuName = "MoneyProviderDataBase")]
    public class MoneyProviderDataBase : ScriptableObject
    {
        [SerializeField] private MoneyProvider[] _products;
        
        //получить продукт по айди
        public MoneyProvider GetProduct(MoneyProviderId id)
        {
            return _products.Single(s => s.ProviderId == id);
        }
    }
}