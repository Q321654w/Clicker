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
        
        public bool CanApply(string id)
        {
            return id == _targetId;
        }

        public Number Apply(Number moneys)
        {
            return moneys * _multiplier;
        }
    }
}