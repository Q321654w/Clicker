namespace DefaultNamespace
{
    public class BuffFactoryFacade : IBuffFactory
    {
        private readonly IBuffFactory[] _buffFactories;

        public BuffFactoryFacade(IBuffFactory[] buffFactories)
        {
            _buffFactories = buffFactories;
        }

        public bool CanCreate(string id)
        {
            var canCreate = false;
            foreach (var buffFactory in _buffFactories)
            {
                canCreate = canCreate || buffFactory.CanCreate(id);
            }

            return canCreate;
        }

        public IBuff Create(string id)
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