using System;
using System.Linq;
using UnityEngine;

namespace DefaultNamespace
{
    [Serializable]
    [CreateAssetMenu(menuName = "NumberFormatter")]
    public class NumberFormatter : ScriptableObject
    {
        [SerializeField] private CharIntPair[] _pair;

        public string FormatToString(Number number)
        {
            var pair = _pair.FirstOrDefault(selectedPair => selectedPair.Int == number.RadixInDegree);
            return number.ToString() + pair.Char;
        }
    }
}