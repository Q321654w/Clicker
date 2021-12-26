using System;

namespace DefaultNamespace
{
    public class BuffFactoryFacade
    {
        private IBuffFactory[] _buffFactories;

        public BuffFactoryFacade(IBuffFactory[] buffFactories)
        {
            _buffFactories = buffFactories;
        }

        public IBuff CreateMultiplyBuff(string id)
        {
            foreach (var factory in _buffFactories)
            {
                if (factory.CanCreate(id))
                    return factory.Create(id);
            }

            throw new Exception();
        }
    }
}