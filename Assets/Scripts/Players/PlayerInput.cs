using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerInput : IGameUpdate
    {
        public event Action<Vector2> Clicked;
        public event Action<IGameUpdate> UpdateRemoveRequested;

        private readonly KeyCode _clickKey;

        public PlayerInput(KeyCode clickKey)
        {
            _clickKey = clickKey;
        }

        public void GameUpdate(float deltaTime)
        {
            if (!Input.GetKeyDown(_clickKey)) return;
            
            var mousePosition = Input.mousePosition;
            Clicked?.Invoke(mousePosition);
        }
    }
}