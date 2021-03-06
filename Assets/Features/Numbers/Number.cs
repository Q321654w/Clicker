using System;
using UnityEngine;

namespace DefaultNamespace
{
    [Serializable]
    public struct Number
    {
        [SerializeField] private double _numeric;
        [SerializeField] private int _radixDegree;

        public int RadixInDegree => _radixDegree;

        private const int RADIX = 1000;

        public Number(int radixDegree, double numeric)
        {
            _radixDegree = radixDegree;
            _numeric = numeric;

            FormatToStandartNumberFormat();
        }

        private void FormatToStandartNumberFormat()
        {
            if (_numeric != 0)
                while (Math.Abs(_numeric) >= RADIX)
                {
                    _numeric /= RADIX;
                    _radixDegree++;
                }

            Ceil();

            while (Math.Abs(_numeric) >= RADIX)
            {
                _numeric /= RADIX;
                _radixDegree++;
            }
        }

        private void Ceil()
        {
            var radixInDegree = (int) Mathf.Pow(RADIX, Mathf.Abs(_radixDegree));

            _numeric *= radixInDegree;
            _numeric = Math.Ceiling(_numeric);
            _numeric /= radixInDegree;
        }

        public override string ToString()
        {
            return $"{_numeric}";
        }

        public static Number operator +(Number number1, Number number2)
        {
            if (number1._radixDegree == number2._radixDegree)
            {
                var numeric = number1._numeric + number2._numeric;
                var nullsCount = number1._radixDegree;

                return new Number(nullsCount, numeric);
            }
            else
            {
                var difference = Mathf.Abs(number1._radixDegree - number2._radixDegree);
                var biggerNumber = number1 > number2 ? number1 : number2;
                var smallerNumber = number1 < number2 ? number1 : number2;

                var numeric = biggerNumber._numeric + smallerNumber._numeric / Mathf.Pow(RADIX, difference);
                var nullsCount = biggerNumber._radixDegree;

                return new Number(nullsCount, numeric);
            }
        }

        public static Number operator -(Number number1, Number number2)
        {
            if (number1._radixDegree == number2._radixDegree)
            {
                var numeric = number1._numeric - number2._numeric;
                var nullsCount = number1._radixDegree;

                return new Number(nullsCount, numeric);
            }
            else
            {
                var difference = Mathf.Abs(number1._radixDegree - number2._radixDegree);
                var biggerNumber = number1 > number2 ? number1 : number2;
                var smallerNumber = number1 < number2 ? number1 : number2;

                var numeric = biggerNumber._numeric - smallerNumber._numeric / Mathf.Pow(RADIX, difference);
                var nullsCount = biggerNumber._radixDegree;

                return new Number(nullsCount, numeric);
            }
        }

        public static Number operator *(Number number1, float number2)
        {
            var numeric = number1._numeric * number2;
            var nullsCount = number1._radixDegree;
            return new Number(nullsCount, numeric);
        }

        public static bool operator >(Number number1, Number number2)
        {
            if (number1._radixDegree == number2._radixDegree)
            {
                return number1._numeric > number2._numeric;
            }

            return number1._radixDegree > number2._radixDegree;
        }

        public static bool operator <(Number number1, Number number2)
        {
            if (number1._radixDegree == number2._radixDegree)
            {
                return number1._numeric < number2._numeric;
            }

            return number1._radixDegree < number2._radixDegree;
        }

        public static bool operator >=(Number number1, Number number2)
        {
            if (number1._radixDegree == number2._radixDegree)
            {
                return number1._numeric >= number2._numeric;
            }

            return number1._radixDegree >= number2._radixDegree;
        }

        public static bool operator <=(Number number1, Number number2)
        {
            if (number1._radixDegree == number2._radixDegree)
            {
                return number1._numeric <= number2._numeric;
            }

            return number1._radixDegree <= number2._radixDegree;
        }
    }
}