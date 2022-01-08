using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace DefaultNamespace
{
    public class BinarySaveSystem : ISaveSystem
    {
        private string _path = Application.persistentDataPath + "/GetGameData.dat";
        
        public void Save(GameData game)
        {
            var binaryFormatter = new BinaryFormatter();

            using var stream = new FileStream(_path, FileMode.Create);
            binaryFormatter.Serialize(stream, game);
        }

        public bool CanLoad()
        {
            return File.Exists(_path);
        }

        public GameData Load()
        {
            var binaryFormatter = new BinaryFormatter();
            using var stream = new FileStream(_path, FileMode.Open);
            
            var gameData = binaryFormatter.Deserialize(stream) as GameData;
            return gameData;
        }
    }
}