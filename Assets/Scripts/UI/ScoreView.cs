using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private Text _score;

        private NumberFormatter _numberFormatter;

        public void Initialize(Wallet wallet, NumberFormatter numberFormatter)
        {
            _numberFormatter = numberFormatter;
            wallet.MoneyCountChanged += OnMoneyCountChanged;
        }

        private void OnMoneyCountChanged(Number number)
        {
            var message = _numberFormatter.FormatToString(number);
            _score.text = $"{message}";
        }
    }
}