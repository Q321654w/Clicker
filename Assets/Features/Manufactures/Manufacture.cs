using System;

namespace DefaultNamespace
{
    [Serializable]
    public class Manufacture
    {
        private readonly string _id;
        
        private readonly Number _money;

        public string Id => _id;
        
        public Manufacture(Number money, string id)
        {
            _money = money;
            _id = id;
        }
        
        public Number GetMoney()
        {
            return _money;
        }
    }
}