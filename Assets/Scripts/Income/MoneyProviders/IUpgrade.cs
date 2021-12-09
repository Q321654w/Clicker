﻿using System;

namespace DefaultNamespace
{
    public interface IUpgrade
    {
        event Action<int> Upgraded;
        
        void Upgrade();
    }
}