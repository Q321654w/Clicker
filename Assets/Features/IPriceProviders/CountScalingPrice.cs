using System;
using UnityEngine;

namespace DefaultNamespace
{
    [Serializable]
    public class CountScalingPrice : IPriceProvider
    {
        public event Action<Number> PriceChanged;

        private readonly string _itemId;
        private readonly Number _basePrice;
        private readonly Inventory _inventory;

        private Number _price;
        private int _count;

        private const float BASE_DEGREE = 1.15f;

        public CountScalingPrice(Inventory inventory, Number basePrice, string itemId)
        {
            _inventory = inventory;
            _inventory.ItemAdded += OnItemAdded;

            _basePrice = basePrice;
            _price = _basePrice;
            _itemId = itemId;

            _count = _inventory.GetCountOf(_itemId);
        }

        private void OnItemAdded(string id)
        {
            if (id != _itemId)
                return;

            _count++;
            _price = _basePrice * Mathf.Pow(BASE_DEGREE, _count);
            PriceChanged?.Invoke(_price);
        }

        public Number GetPrice()
        {
            return _price;
        }

        public PriceProviderData GetData()
        {
            return new PriceProviderData(_itemId, _basePrice);
        }
    }
}