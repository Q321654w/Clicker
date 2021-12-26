namespace DefaultNamespace
{
    public class ManufactureFactory
    {
        private readonly ManufactureDataBase _dataBase;

        public ManufactureFactory(ManufactureDataBase dataBase)
        {
            _dataBase = dataBase;
        }

        public Manufacture Create(string id)
        {
            var config = _dataBase.GetMoneyProvider(id);
            return new Manufacture(config.Number, config.Id);
        }
    }
}