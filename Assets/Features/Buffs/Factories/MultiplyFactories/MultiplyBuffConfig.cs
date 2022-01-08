using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(menuName = "Buffs/Configs/MultiplyBuffConfig")]
    public class MultiplyBuffConfig : ScriptableObject
    {
        [SerializeField] private int _multiplier;
        [SerializeField] private string _id;
        [SerializeField] private string _targetId;

        public int Multiplier => _multiplier;
        public string Id => _id;
        public string TargetId => _targetId;
    }
}