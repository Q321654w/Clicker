using System.Linq;

namespace DefaultNamespace
{
    public class CountScalingBuffFactory : IBuffFactory
    {
        private readonly CountScalingBuffConfig[] _configs;
        private readonly Inventory _inventory;
        private readonly string _idContext;

        public CountScalingBuffFactory(Inventory inventory, string idContext, CountScalingBuffConfig[] configs)
        {
            _inventory = inventory;
            _idContext = idContext;
            _configs = configs;
        }

        public bool CanCreate(string id)
        {
            return id.Contains(_idContext);
        }

        public IBuff Create(string id)
        {
            var config = _configs.Single(s => s.Id == id);
            return new CountScalingBuff(_inventory, config.Number, config.TargetId);
        }
    }
}