using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private Text _score;
        [SerializeField] private Text _moneyPerSecond;

        private NumberFormatter _numberFormatter;
        private IncomeProvider _incomeProvider;

        public void Initialize(Wallet wallet, NumberFormatter numberFormatter, IncomeProvider incomeProvider)
        {
            _incomeProvider = incomeProvider;
            _numberFormatter = numberFormatter;

            wallet.MoneyCountChanged += OnMoneyCountChanged;
            _incomeProvider.IncomeChanged += OnIncomeChanged;
        }

        private void OnIncomeChanged(Number number)
        {
            var formatedNumber = _numberFormatter.FormatToString(number);
            _moneyPerSecond.text = $"{formatedNumber}";
        }

        private void OnMoneyCountChanged(Number number)
        {
            var formatedNumber = _numberFormatter.FormatToString(number);
            _score.text = $"{formatedNumber}";
        }
    }
}