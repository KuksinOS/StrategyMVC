﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyMVC.Rounding
{
    public class BRoundingTo3 : IRounding
    {
        public decimal Rounding(decimal value)
        {
            return Math.Round(value, 3);
        }

    }
}
