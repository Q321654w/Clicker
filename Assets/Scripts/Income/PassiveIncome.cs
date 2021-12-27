using System;
using System.Collections.Generic;

namespace DefaultNamespace
{
    public class PassiveIncome : IGameUpdate
    {
        public event Action<IGameUpdate> UpdateRemoveRequested;

        private readonly Wallet _wallet;
        private readonly IEnumerable<Manufacture> _manufactures;
        private float _incomeDelay = 1f;
        private float _passedTime;

        public PassiveIncome(Wallet wallet, IEnumerable<Manufacture> incomeProvider)
        {
            _wallet = wallet;
            _manufactures = incomeProvider;
        }

        public void GameUpdate(float deltaTime)
        {
            _passedTime += deltaTime;
            if (_passedTime < _incomeDelay)
                return;

            _passedTime = 0;
            
            var income = new Number(0,0);
            
            foreach (var manufacture in _manufactures)
            {
                income += manufacture.GetMoney();
            }
            
            _wallet.AddMoney(income);
        }
    }
}