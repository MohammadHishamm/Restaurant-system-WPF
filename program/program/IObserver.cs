﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program
{
    internal interface IObserver
    {
        void Update(Order order);
        void NotifyCustomer(Order order);
    }
}