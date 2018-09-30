using StrategyMVC.DAL;
using StrategyMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyMVC.Controllers
{
    public class SpeciesController
    {
      
        static readonly IRepository<Species> repositorySpecies = new SpeciesRepository();

       
        public ICollection<Species> GetAll()
        {
            return repositorySpecies.GetAll();
        }

        public Species Get(int speciesId)
        {
            return repositorySpecies.Get(speciesId);
        }

        public string Add(Species species)
        {
            try
            {
                if (repositorySpecies.IsValid(species))
                {

                    repositorySpecies.Add(species);
                    return "OK";
                }
                else
                {
                    return "BadRequest !";
                }
            }
            catch (Exception ex)
            {

                return ex.ToString();
            }
        }

        public string Upd(Species species)
        {
            try
            {
                if (repositorySpecies.IsValid(species))
                {
                    Species item = repositorySpecies.Get(species.SpeciesId);

                    if (item != null)
                    {
                        item.SpeciesName = species.SpeciesName;
                        if (repositorySpecies.Update(item))
                        {
                            return "OK";
                        }
                        else
                        {
                            return "Something wrong !";
                        }
                    }
                    else
                    {
                        return "Not Found !";
                    }

                }
                else
                {
                    return "BadRequest !";
                }

            }
            catch (Exception ex)
            {

                return ex.ToString();
            }
        }

        public string Del(int speciesId)
        {
            try
            {

                Species item = repositorySpecies.Get(speciesId);
                if (item != null)
                {
                    repositorySpecies.Remove(item.SpeciesId);
                    return "OK";
                }

                else
                {
                    return "Something wrong !";
                }
            }
            catch (Exception ex)
            {

                return ex.ToString();
            }
        }

    }
}
