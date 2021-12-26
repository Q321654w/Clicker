namespace DefaultNamespace
{
    public class MultiplyBuff : IBuff
    {
        private readonly int _multiplier;
        private readonly string _targetId;

        public MultiplyBuff(int multiplier, string targetId)
        {
            _multiplier = multiplier;
            _targetId = targetId;
        }

        public bool TryApply(string id, Number moneys, out Number buffedMoneys)
        {
            buffedMoneys = new Number(0, 0);

            if (id != _targetId)
                return false;

            buffedMoneys = moneys * _multiplier;
            return true;
        }
    }
}