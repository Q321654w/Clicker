namespace DefaultNamespace
{
    public interface ISaveSystem
    {
        void Save(GameData game);
        bool CanLoad();
        GameData Load();
    }
}