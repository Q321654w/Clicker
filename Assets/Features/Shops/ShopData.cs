using System;
using System.Collections.Generic;

namespace DefaultNamespace
{
    [Serializable]
    public readonly struct ShopData
    {
        private readonly Dictionary<ProductId, int> _catalog;

        public ShopData(Dictionary<ProductId, int> catalog)
        {
            _catalog = catalog;
        }

        public ShopData(ProductDataBase _productDataBase)
        {
            _catalog = new Dictionary<ProductId, int>();

            foreach (var productConfig in _productDataBase.ProductConfigs)
            {
                _catalog.Add(productConfig.ProductId, productConfig.BaseCount);
            }
        }

        public Dictionary<ProductId, int> Catalog => _catalog;
    }
}