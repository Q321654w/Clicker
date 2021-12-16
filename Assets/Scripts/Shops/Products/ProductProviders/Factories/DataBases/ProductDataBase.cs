using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(menuName = "ProductDataBase")]
    public class ProductDataBase : ScriptableObject
    {
        [SerializeField] private ProductConfig[] _productConfigs;

        public IEnumerable<ProductConfig> ProductConfigs => _productConfigs;

        public ProductConfig GetProductConfig(ProductId id)
        {
            return _productConfigs.Single(s => s.ProductId == id);
        }
    }
}