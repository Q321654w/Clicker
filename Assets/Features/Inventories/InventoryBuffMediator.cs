namespace DefaultNamespace
{
    public class InventoryBuffMediator : ICleanUp
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
            if (!_factoryFacade.CanCreate(id)) 
                return;
            
            var buff = _factoryFacade.Create(id);
            _incomeProvider.AddBuff(buff);
        }

        public void CleanUp()
        {
            _inventory.ItemAdded -= OnItemAdded;
        }
    }
}