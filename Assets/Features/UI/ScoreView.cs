using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class ScoreView : MonoBehaviour, ICleanUp
    {
        [SerializeField] private Text _score;
        [SerializeField] private Text _moneyPerSecond;

        private NumberFormatter _numberFormatter;

        private IncomeProvider _incomeProvider;
        private Wallet _wallet;

        public void Initialize(IncomeProvider incomeProvider, Wallet wallet, NumberFormatter numberFormatter)
        {
            _incomeProvider = incomeProvider;
            _numberFormatter = numberFormatter;
            _wallet = wallet;

            OnIncomeChanged(incomeProvider.Income);
            OnMoneyCountChanged(wallet.Money);

            _wallet.MoneyCountChanged += OnMoneyCountChanged;
            _incomeProvider.IncomeChanged += OnIncomeChanged;
        }

        private void OnIncomeChanged(Number number)
        {
            var formatedNumber = _numberFormatter.FormatToString(number);
            _moneyPerSecond.text = $"{formatedNumber}";
        }

        private void OnMoneyCountChanged(Number number)
        {
            var message = _numberFormatter.FormatToString(number);
            _score.text = $"{message}";
        }

        public void CleanUp()
        {
            _wallet.MoneyCountChanged -= OnMoneyCountChanged;
            _incomeProvider.IncomeChanged -= OnIncomeChanged;
        }
    }
}