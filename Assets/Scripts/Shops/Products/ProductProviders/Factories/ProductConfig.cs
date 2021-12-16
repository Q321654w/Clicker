using System;
using UnityEngine;

namespace DefaultNamespace
{
    [Serializable]
    public struct ProductConfig
    {
        [SerializeField] private ProductId _productProductId;
        [SerializeField] private string _name;
        [SerializeField] private string _id;
        [SerializeField] private Number _basePrice;
        [SerializeField] private int _baseCount;

        public ProductId ProductId => _productProductId;
        public string Name => _name;
        public string Id => _id;
        public Number BasePrice => _basePrice;
        public int BaseCount => _baseCount;
    }
}