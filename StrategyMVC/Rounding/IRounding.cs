using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyMVC.Rounding
{
    public interface IRounding
    {
        decimal Rounding(decimal unit);
    }
}
