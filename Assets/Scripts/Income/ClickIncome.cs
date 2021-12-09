namespace DefaultNamespace
{
    public class ClickIncome
    {
        private readonly Wallet _wallet;
        private readonly CustomButton _button;
        private readonly MoneyProvider _moneyProvider;

        public ClickIncome(Wallet wallet, CustomButton button, MoneyProvider moneyProvider)
        {
            _wallet = wallet;
            _button = button;
            _moneyProvider = moneyProvider;
            _button.Clicked += OnClicked;
        }

        private void OnClicked()
        {
            var income = _moneyProvider.GetMoney();
            _wallet.AddMoney(income);
        }
    }
}