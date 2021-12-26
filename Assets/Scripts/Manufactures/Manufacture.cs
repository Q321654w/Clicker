namespace DefaultNamespace
{
    public class Manufacture
    {
        private Number _number;
        private string _id;

        public string Id => _id;

        public Manufacture(Number number, string id)
        {
            _number = number;
            _id = id;
        }

        public Number GetMoney()
        {
            return _number;
        }
    }
}