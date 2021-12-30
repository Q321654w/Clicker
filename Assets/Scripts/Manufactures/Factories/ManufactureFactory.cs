namespace DefaultNamespace
{
    public class ManufactureFactory
    {
        private readonly ManufactureDataBase _dataBase;
        private readonly string _idContext;

        public ManufactureFactory(string idContext, ManufactureDataBase dataBase)
        {
            _dataBase = dataBase;
            _idContext = idContext;
        }

        public bool CanCreate(string id)
        {
            return id.Contains(_idContext);
        }

        public Manufacture Create(string id)
        {
            var config = _dataBase.GetMoneyProvider(id);
            return new Manufacture(config.Number, config.Id);
        }
    }
}