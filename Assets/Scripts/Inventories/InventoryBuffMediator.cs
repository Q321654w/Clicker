namespace DefaultNamespace
{
    public class InventoryBuffMediator
    {
        private readonly Inventory _inventory;
        private readonly IncomeProvider _incomeProvider;
        private readonly BuffFactoryFacade _factoryFacade;

        public InventoryBuffMediator(IncomeProvider incomeProvider, BuffFactoryFacade factoryFacade, Inventory inventory)
        {
            _incomeProvider = incomeProvider;
            _factoryFacade = factoryFacade;
            _inventory = inventory;
            _inventory.ItemAdded += OnItemAdded;
        }

        private void OnItemAdded(string id)
        {
            var buff = _factoryFacade.CreateMultiplyBuff(id);
            _incomeProvider.AddBuff(buff);
        }
    }
}