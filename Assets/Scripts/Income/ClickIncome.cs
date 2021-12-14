namespace DefaultNamespace
{
    public class ClickIncome
    {
        private readonly Wallet _wallet;
        private readonly CustomButton _button;
        private readonly IncomeProvider _incomeProvider;

        public ClickIncome(Wallet wallet, CustomButton button, IncomeProvider incomeProvider)
        {
            _wallet = wallet;
            _button = button;
            _incomeProvider = incomeProvider;
            _button.Clicked += OnClicked;
        }

        private void OnClicked()
        {
            var income = _incomeProvider.GetIncome();
            _wallet.AddMoney(income);
        }
    }
}