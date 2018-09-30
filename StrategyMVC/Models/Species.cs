using StrategyMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyMVC.Models
{
    public class Species
    {
        public int SpeciesId { get; set; }
        public string SpeciesName { get; set; }
        public virtual Types Types { get; set; }

        public virtual ICollection<Product> Products { get; set; }



    }
}
