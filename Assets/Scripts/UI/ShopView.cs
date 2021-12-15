using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class ShopView : MonoBehaviour
    {
        [SerializeField] private CustomButton _buttonPrefab;
        [SerializeField] private Transform _content;

        private Shop _shop;
        private Dictionary<int, ProductId> _buttons;

        public void Initialize(IEnumerable<Product> products, Shop shop)
        {
            _shop = shop;
            _buttons = new Dictionary<int, ProductId>();

            foreach (var product in products)
            {
                var button = Instantiate(_buttonPrefab, _content);
                button.Initialize(product.Name);
                button.Clicked += OnClicked;
                _buttons.Add(button.GetHashCode(), product.ProductId);
            }
        }

        private void OnClicked(CustomButton button)
        {
            _buttons.TryGetValue(button.GetHashCode(), out var id);
            _shop.Buy(id);
        }
    }
}