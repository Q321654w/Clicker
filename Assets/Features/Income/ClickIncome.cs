namespace DefaultNamespace
{
    public class ClickIncome : ICleanUp
    {
        private readonly Wallet _wallet;
        private readonly CustomButton _button;
        private readonly IncomeProvider _incomeProvider;

        public ClickIncome(Wallet wallet, CustomButton button, IncomeProvider incomeProvider)
        {
            _wallet = wallet;
            _button = button;
            _incomeProvider = incomeProvider;
            _button.Pressed += OnPressed;
        }

        private void OnPressed()
        {
            var income = _incomeProvider.Income;
            _wallet.AddMoney(income);
        }

        public void CleanUp()
        {
            _button.Pressed -= OnPressed;
        }
    }
}