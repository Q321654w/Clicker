using System;
using UnityEngine;

namespace DefaultNamespace
{
    [Serializable]
    public struct ProductId : IEquatable<ProductId>
    {
        [SerializeField] private int _id;

        public ProductId(int id)
        {
            _id = id;
        }

        public static bool operator ==(ProductId id1, ProductId id2)
        {
            return id1._id == id2._id;
        }

        public static bool operator !=(ProductId id1, ProductId id2)
        {
            return id1._id != id2._id;
        }
        
        public bool Equals(ProductId other)
        {
            return _id == other._id;
        }

        public override bool Equals(object obj)
        {
            return obj is ProductId other && Equals(other);
        }

        public override int GetHashCode()
        {
            return _id;
        }
    }
}