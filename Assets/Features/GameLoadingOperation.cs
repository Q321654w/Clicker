using System;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace DefaultNamespace
{
    public class GameLoadingOperation : ILoadingOperation
    {
        private delegate Game GetGame();
        
        private const int INDEX_OF_GAME_INSTALLER_SCENE = 1;
        private readonly ISaveSystem _saveSystem;

        public GameLoadingOperation(ISaveSystem saveSystem)
        {
            _saveSystem = saveSystem;
        }

        public string Description => "Game loading...";

        public async Task Load(Action<float> onProgress)
        {
            onProgress?.Invoke(0.5f);
            
            var loadOperation = SceneManager.LoadSceneAsync(INDEX_OF_GAME_INSTALLER_SCENE, LoadSceneMode.Additive);
            while (loadOperation.isDone == false)
            {
                await Task.Delay(1);
            }
            
            var unloadOperation = SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
            while (unloadOperation.isDone == false)
            {
                await Task.Delay(1);
            }

            var gameInstaller = Object.FindObjectOfType<GameInstaller>();
            GetGame getGame;

            var canLoad = _saveSystem.CanLoad();
            if (canLoad)
            {
                var data = _saveSystem.Load();
                getGame = () => gameInstaller.CreateGame(data);
            }
            else
            {
                getGame = gameInstaller.StartNew;
            }

            onProgress?.Invoke(1f);
            await Task.Delay(2000);
            
            var game = getGame.Invoke();
            game.Start();
        }
    }
}