using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class ShopView : MonoBehaviour, ICleanUp
    {
        [SerializeField] private ProductView _productViewPrefab;
        [SerializeField] private RectTransform _content;

        private List<ProductView> _productViews;
        private Shop _shop;

        public void Initialize(IEnumerable<Product> products, Shop shop, NumberFormatter numberFormatter)
        {
            _shop = shop;
            _productViews = new List<ProductView>();
            
            foreach (var product in products)
            {
                var productView = Instantiate(_productViewPrefab, _content);
                productView.Initialize(numberFormatter, product, shop);
                _productViews.Add(productView);
            }
        }

        public void CleanUp()
        {
            foreach (var productView in _productViews)
            {
                productView.CleanUp();
            }
        }
    }
}