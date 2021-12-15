using System;
using UnityEngine;

namespace DefaultNamespace
{
    [Serializable]
    public struct Product
    {
        [SerializeField] private ProductId _productId;
        [SerializeField] private string _name;
        [SerializeField] private string _id;
        [SerializeField] private Number _price;
        [SerializeField] private int _count;
        
        public ProductId ProductId => _productId;
        public string Name => _name;
        public string Id => _id;
        public Number Price => _price;
        public int Count => _count;

    }
}