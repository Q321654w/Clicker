using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class ShopView : MonoBehaviour
    {
        [SerializeField] private ProductView _productViewPrefab;
        [SerializeField] private Transform _content;

        private Shop _shop;
        private Dictionary<int, ProductId> _productViews;

        public void Initialize(IEnumerable<Product> products, Shop shop, NumberFormatter numberFormatter)
        {
            _shop = shop;
            _productViews = new Dictionary<int, ProductId>();

            foreach (var product in products)
            {
                var productView = Instantiate(_productViewPrefab, _content);
                productView.Initialize(product.Name, product.PriceProvider, numberFormatter);
                productView.Clicked += OnClicked;
                _productViews.Add(productView.GetHashCode(), product.ProductId);
            }
        }

        private void OnClicked(ProductView button)
        {
            _productViews.TryGetValue(button.GetHashCode(), out var id);
            _shop.Buy(id);
        }
    }
}