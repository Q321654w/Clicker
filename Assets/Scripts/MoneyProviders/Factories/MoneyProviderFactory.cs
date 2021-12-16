namespace DefaultNamespace
{
    public class MoneyProviderFactory
    {
        private readonly MoneyProviderDataBase _dataBase;

        public MoneyProviderFactory(MoneyProviderDataBase dataBase)
        {
            _dataBase = dataBase;
        }

        public MoneyProvider Create(string id)
        {
            var config = _dataBase.GetMoneyProvider(id);
            return new MoneyProvider(config);
        }
    }
}