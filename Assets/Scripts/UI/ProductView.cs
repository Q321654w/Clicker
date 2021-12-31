﻿using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class ProductView : MonoBehaviour
    {
        [SerializeField] private Text _countText;
        [SerializeField] private Text _priceText;
        [SerializeField] private CustomButton _customButton;

        private Shop _shop;
        private NumberFormatter _numberFormatter;
        private Product _product;

        public void Initialize(NumberFormatter numberFormatter, Product product, Shop shop)
        {
            _shop = shop;
            _product = product;
            _numberFormatter = numberFormatter;

            OnProductSold(_product);
            OnPriceChanged(_product.Price.GetPrice());
            _customButton.Initialize(_product.Name);

            _shop.ProductSold += OnProductSold;
            _product.Price.PriceChanged += OnPriceChanged;
            _customButton.Clicked += OnClicked;
        }

        private void OnProductSold(Product product)
        {
            if (product.ProductId != _product.ProductId)
                return;

            var count = _shop.GetCountOf(product.ProductId);

            if (count < 0)
                _countText.text = "infinity";
            else
                _countText.text = $"{count}";
        }

        private void OnPriceChanged(Number number)
        {
            var formatedNumber = _numberFormatter.FormatToString(number);
            _priceText.text = $"{formatedNumber}";
        }

        private void OnClicked()
        {
            _shop.Buy(_product.ProductId);
        }
    }
}