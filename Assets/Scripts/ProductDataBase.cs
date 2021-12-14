using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DefaultNamespace
{
    //хранение всех продуктов в игре 
    [CreateAssetMenu(menuName = "ProductDataBase")]
    public class ProductDataBase : ScriptableObject
    {
        [SerializeField] private Product[] _products;
        public IEnumerable<Product> Products => _products;
        
        //получить продукт по айди
        public Product GetProduct(ProductId id)
        {
            return _products.Single(s => s.Id == id);
        }
    }
}