namespace DefaultNamespace
{
    public class InventoryIncomeProviderMediator
    {
        private readonly IncomeProvider _incomeProvider;
        private readonly Inventory _inventory;
        private readonly MoneyProviderDataBase _providerDataBase;

        public InventoryIncomeProviderMediator(IncomeProvider incomeProvider, Inventory inventory, MoneyProviderDataBase providerDataBase)
        {
            _incomeProvider = incomeProvider;
            _inventory = inventory;
            _providerDataBase = providerDataBase;
            _inventory.ItemAdded += OnItemAdded;
        }

        private void OnItemAdded(MoneyProviderId id)
        {
            var moneyProvider = _providerDataBase.GetProduct(id);
            _incomeProvider.AddMoneyProvider(moneyProvider);
        }
    }
}