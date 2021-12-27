using System.Collections.Generic;

namespace DefaultNamespace
{
    public class ClickIncome
    {
        private readonly Wallet _wallet;
        private readonly CustomButton _button;
        private readonly IEnumerable<Manufacture> _incomeProvider;

        public ClickIncome(Wallet wallet, CustomButton button, IEnumerable<Manufacture> incomeProvider)
        {
            _wallet = wallet;
            _button = button;
            _incomeProvider = incomeProvider;
            _button.Clicked += OnClicked;
        }

        private void OnClicked()
        {
            var income = new Number(0,0);
            foreach (var manufacture in _incomeProvider)
            {
                income += manufacture.GetMoney();
            }
            
            _wallet.AddMoney(income);
        }
    }
}