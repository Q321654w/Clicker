using System.Linq;

namespace DefaultNamespace
{
    public class MultiplyBuffFactory : IBuffFactory
    {
        private readonly MultiplyBuffConfig[] _multiplyBuffConfigs;
        private readonly string _idContext;

        public MultiplyBuffFactory(string idContext, MultiplyBuffConfig[] multiplyBuffConfigs)
        {
            _idContext = idContext;
            _multiplyBuffConfigs = multiplyBuffConfigs;
        }

        public bool CanCreate(string id)
        {
            return id.Contains(_idContext);
        }

        public IBuff Create(string id)
        {
            var config = _multiplyBuffConfigs.Single(s => s.Id == id);
            return new MultiplyBuff(config.Multiplier, config.TargetId);
        }
    }
}