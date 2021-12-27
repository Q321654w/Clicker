using System.Collections.Generic;

namespace DefaultNamespace
{
    public class InventoryBuffMediator
    {
        private readonly Inventory _inventory;
        private readonly IEnumerable<Manufacture> _manufactures;
        private readonly BuffFactoryFacade _factoryFacade;

        public InventoryBuffMediator(IEnumerable<Manufacture> incomeProvider, BuffFactoryFacade factoryFacade, Inventory inventory)
        {
            _manufactures = incomeProvider;
            _factoryFacade = factoryFacade;
            _inventory = inventory;
            _inventory.ItemAdded += OnItemAdded;
        }

        private void OnItemAdded(string id)
        {
            var buff = _factoryFacade.CreateMultiplyBuff(id);
            foreach (var manufacture in _manufactures)
            {
                if (buff.CanApply(manufacture.Id))
                {
                    manufacture.AddBuff(buff);
                }
            }
        }
    }
}