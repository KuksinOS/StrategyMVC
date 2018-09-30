using StrategyMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyMVC.DAL
{
    public class SpeciesRepository : IRepository<Species>
    {
        private List<Species> species = new List<Species>();

       
        public ICollection<Species> GetAll()
        {
            return species;
        }

        public Species Get(int speciesId)
        {
            return species.Find(s => s.SpeciesId == speciesId);
        }

        public Species Add(Species item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
           // item.SpeciesId = species.Max(s => s.SpeciesId) + 1;
            species.Add(item);
            return item;
        }

        public void Remove(int speciesId)
        {
            species.RemoveAll(t => t.SpeciesId == speciesId);
        }

        public bool Update(Species item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = species.FindIndex(s => s.SpeciesId == item.SpeciesId);
            if (index == -1)
            {
                return false;
            }
            species.RemoveAt(index);
            species.Add(item);
            return true;
        }

        public bool IsValid(Species item)
        {
            return (item.SpeciesName != null);
        }


    }
}
