using System.Linq;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(menuName = "ManufactureDataBase")]
    public class ManufactureDataBase : ScriptableObject
    {
        [SerializeField] private ManufactureConfig[] _manufactureConfigs;

        public ManufactureConfig GetManufactureConfig(string id)
        {
            return _manufactureConfigs.Single(s => s.Id == id);
        }
    }
}