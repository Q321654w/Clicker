using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class ShopView : MonoBehaviour
    {
        [SerializeField] private ProductView _productViewPrefab;
        [SerializeField] private RectTransform _content;

        private Shop _shop;

        public void Initialize(IEnumerable<Product> products, Shop shop, NumberFormatter numberFormatter)
        {
            _shop = shop;
            
            foreach (var product in products)
            {
                var productView = Instantiate(_productViewPrefab, _content);
                productView.Initialize(numberFormatter, product, shop);
            }
        }
    }
}