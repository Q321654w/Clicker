﻿namespace DefaultNamespace
{
    public class InventoryManufactureMediator
    {
        private readonly IncomeProvider _incomeProvider;
        private readonly Inventory _inventory;
        private readonly ManufactureFactory _manufactureFactory;

        public InventoryManufactureMediator(IncomeProvider incomeProvider, Inventory inventory, ManufactureFactory manufactureFactory)
        {
            _incomeProvider = incomeProvider;
            _inventory = inventory;
            _manufactureFactory = manufactureFactory;
            _inventory.ItemAdded += OnItemAdded;
        }

        private void OnItemAdded(string id)
        {
            var moneyProvider = _manufactureFactory.Create(id);
            _incomeProvider.AddMoneyProvider(moneyProvider);
        }
    }
}