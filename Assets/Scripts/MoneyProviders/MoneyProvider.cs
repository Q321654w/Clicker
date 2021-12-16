namespace DefaultNamespace
{
    public class MoneyProvider
    {
        private readonly Number _number; 
        
        public MoneyProvider(MoneyProviderConfig config)
        {
            _number = config.Number;
        }

        public Number GetMoney()
        {
           return _number;
        }
    }
}