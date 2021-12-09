using System;

namespace DefaultNamespace
{
    public interface IGameUpdate
    {
        event Action<IGameUpdate> UpdateRemoveRequested;
        
        void GameUpdate(float deltaTime);
    }
}