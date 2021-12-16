namespace DefaultNamespace
{
    public class InventoryIncomeProviderMediator
    {
        private readonly IncomeProvider _incomeProvider;
        private readonly Inventory _inventory;
        private readonly MoneyProviderFactory _moneyProviderFactory;

        public InventoryIncomeProviderMediator(IncomeProvider incomeProvider, Inventory inventory, MoneyProviderFactory moneyProviderFactory)
        {
            _incomeProvider = incomeProvider;
            _inventory = inventory;
            _moneyProviderFactory = moneyProviderFactory;
            _inventory.ItemAdded += OnItemAdded;
        }

        private void OnItemAdded(string id)
        {
            var moneyProvider = _moneyProviderFactory.Create(id);
            _incomeProvider.AddMoneyProvider(moneyProvider);
        }
    }
}