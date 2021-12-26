namespace DefaultNamespace
{
    public interface IBuff
    {
        bool TryApply(string id, Number moneys, out Number buffedMoneys);
    }
}