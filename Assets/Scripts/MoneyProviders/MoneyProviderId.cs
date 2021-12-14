using System;
using UnityEngine;

namespace DefaultNamespace
{
    [Serializable]
    public struct MoneyProviderId : IEquatable<MoneyProviderId>
    {
        [SerializeField] private string _id;
        public string Id => _id;

        public MoneyProviderId(string id)
        {
            _id = id;
        }
        
        public static bool operator ==(MoneyProviderId id1, MoneyProviderId id2)
        {
            return id1._id == id2._id;
        }

        public static bool operator !=(MoneyProviderId id1, MoneyProviderId id2)
        {
            return id1._id != id2._id;
        }
        
        public bool Equals(MoneyProviderId other)
        {
            return _id == other._id;
        }

        public override bool Equals(object obj)
        {
            return obj is MoneyProviderId other && Equals(other);
        }

        public override int GetHashCode()
        {
            return _id.GetHashCode();
        }
    }
}