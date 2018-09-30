using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyMVC.Models
{
    public class Types
    {
        public int TypesId { get; set; }
        public string TypesName { get; set; }

        public virtual ICollection<Species> Species { get; set; }


    }
}
