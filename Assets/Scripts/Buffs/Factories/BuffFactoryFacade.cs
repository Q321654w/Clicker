namespace DefaultNamespace
{
    public class BuffFactoryFacade
    {
        private readonly IBuffFactory[] _buffFactories;
        private readonly string _idContext;

        public BuffFactoryFacade(IBuffFactory[] buffFactories, string idContext)
        {
            _buffFactories = buffFactories;
            _idContext = idContext;
        }

        public bool CanCreate(string id)
        {
            return id.Contains(_idContext);
        }

        public IBuff CreateBuff(string id)
        {
            foreach (var factory in _buffFactories)
            {
                if (factory.CanCreate(id))
                    return factory.Create(id);
            }

            return null;
        }
    }
}