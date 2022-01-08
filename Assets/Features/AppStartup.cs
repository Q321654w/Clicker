using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class AppStartup : MonoBehaviour
    {
        [SerializeField] private LoadingScreen _loadingScreen;

        private void Start()
        {
            var loadingOperations = new Queue<ILoadingOperation>();
            loadingOperations.Enqueue(new GameLoadingOperation(new BinarySaveSystem()));
            _loadingScreen.Load(loadingOperations);
        }
    }
}