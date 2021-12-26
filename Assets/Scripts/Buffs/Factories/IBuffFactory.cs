namespace DefaultNamespace
{
    public interface IBuffFactory
    {
        bool CanCreate(string id);
        IBuff Create(string id);
    }
}