namespace DefaultNamespace
{
    public class SimpleMoneyProvider : IMoneyProvider
    {
        private readonly Number _number;

        public SimpleMoneyProvider(Number number)
        {
            _number = number;
        }

        public Number GetMoney()
        {
           return _number;
        }
    }
}