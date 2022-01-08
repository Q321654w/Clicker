using System;

namespace DefaultNamespace
{
    [Serializable]
    public readonly struct PriceProviderData
    {
        private readonly string _itemId;
        private readonly Number _basePrice;

        public PriceProviderData(string itemId, Number basePrice)
        {
            _itemId = itemId;
            _basePrice = basePrice;
        }

        public string ItemId => _itemId;
        public Number BasePrice => _basePrice;
    }
}