using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private Text _score;

        public void Initialize(Wallet wallet)
        {
            wallet.MoneyCountChanged += OnMoneyCountChanged;
        }

        private void OnMoneyCountChanged(Number number)
        {
            _score.text = "" + number;
        }
    }
}