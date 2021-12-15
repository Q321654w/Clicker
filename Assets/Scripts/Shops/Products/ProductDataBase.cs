using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(menuName = "ProductDataBase")]
    public class ProductDataBase : ScriptableObject
    {
        [SerializeField] private Product[] _products;
        public IEnumerable<Product> Products => _products;
        
        public Product GetProduct(ProductId id)
        {
            return _products.Single(s => s.ProductId == id);
        }
    }
}