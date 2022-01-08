using System;
using System.Collections.Generic;
using System.Linq;

namespace DefaultNamespace.ProductProviders
{
    [Serializable]
    public readonly struct ProductProviderData
    {
        private readonly List<ProductData> _productDatas;

        public ProductProviderData(IEnumerable<ProductData> products)
        {
            _productDatas = products.ToList();
        }

        public List<ProductData> ProductDatas => _productDatas;
    }
}