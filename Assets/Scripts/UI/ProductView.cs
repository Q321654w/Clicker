using System;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class ProductView : MonoBehaviour
    {
        public event Action<ProductView> Clicked;
        
        [SerializeField] private Text _count;
        [SerializeField] private Text _price;
        [SerializeField] private CustomButton _customButton;

        private NumberFormatter _numberFormatter;
        private IPriceProvider _priceProvider;

        public void Initialize(string productName, IPriceProvider priceProvider, NumberFormatter numberFormatter)
        {
            _priceProvider = priceProvider;
            _numberFormatter = numberFormatter;
            
            _customButton.Initialize(productName);
            OnPriceChanged(priceProvider.GetPrice());
            
            priceProvider.PriceChanged += OnPriceChanged;
            _customButton.Clicked += OnClicked;
        }

        private void OnPriceChanged(Number number)
        {
            _price.text = $"{_numberFormatter.FormatToString(_priceProvider.GetPrice())}";
        }

        protected void OnClicked()
        {
            Clicked?.Invoke(this);
        }
    }
}