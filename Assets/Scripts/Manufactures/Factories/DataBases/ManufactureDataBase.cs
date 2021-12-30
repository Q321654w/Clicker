using System.Linq;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(menuName = "ManufactureDataBase")]
    public class ManufactureDataBase : ScriptableObject
    {
        [SerializeField] private ManufactureConfig[] _moneyProviders;

        public ManufactureConfig GetMoneyProvider(string id)
        {
            return _moneyProviders.Single(s => s.Id == id);
        }
    }
}