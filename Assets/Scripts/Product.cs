using System;
using UnityEngine;

namespace DefaultNamespace
{
    [Serializable]
    public struct Product
    {
        [SerializeField] private ProductId _id;
        [SerializeField] private string _moneyProviderId;
        [SerializeField] private Number _price;
        [SerializeField] private int _count;
        
        public ProductId Id => _id;
        public string ProviderId => _moneyProviderId;
        public Number Price => _price;
        public int Count => _count;
    }
}