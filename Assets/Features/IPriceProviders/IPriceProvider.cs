using System;

namespace DefaultNamespace
{
    public interface IPriceProvider
    {
        event Action<Number> PriceChanged;
        Number GetPrice();
    }
}