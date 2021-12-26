using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameUpdates : MonoBehaviour
    {
        private List<IGameUpdate> _gameUpdates = new List<IGameUpdate>();

        private bool _isStoped;

        public void Stop()
        {
            _isStoped = true;
        }

        public void Resume()
        {
            _isStoped = false;
        }

        public void AddToUpdates(IGameUpdate update)
        {
            _gameUpdates.Add(update);
        }

        public void RemoveFromUpdates(IGameUpdate update)
        {
            var index = _gameUpdates.IndexOf(update);
            var lastIndex = _gameUpdates.Count - 1;

            _gameUpdates[index] = _gameUpdates[lastIndex];
            _gameUpdates[lastIndex] = update;

            _gameUpdates.RemoveAt(lastIndex);
        }

        private void Update()
        {
            if (_isStoped)
                return;

            var deltaTime = Time.deltaTime;

            for (int i = 0; i < _gameUpdates.Count; i++)
            {
                _gameUpdates[i].GameUpdate(deltaTime);
            }
        }
    }
}