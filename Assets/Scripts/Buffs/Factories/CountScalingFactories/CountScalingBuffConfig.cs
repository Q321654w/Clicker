using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(menuName = "Buffs/Configs/CountScalingBuffConfig")]
    public class CountScalingBuffConfig : ScriptableObject
    {
        [SerializeField] private string _id;
        [SerializeField] private string _targetId;
        [SerializeField] private Number _number;

        public string Id => _id;
        public string TargetId => _targetId;
        public Number Number => _number;
    }
}