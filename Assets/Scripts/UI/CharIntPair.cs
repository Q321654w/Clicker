using System;
using UnityEngine;

namespace DefaultNamespace
{
    [Serializable]
    public class CharIntPair
    {
        [SerializeField] private Char _char;
        [SerializeField] private int _int;

        public char Char => _char;
        public int Int => _int;
    }
}