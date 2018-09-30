using StrategyMVC.DAL;
using StrategyMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyMVC.Controllers
{
    public class TypesController
    {
        static readonly IRepository<Types> repositoryTypes = new TypesRepository();



        public ICollection<Types> GetAll()
        {
            return repositoryTypes.GetAll();
        }

        public Types Get(int typesId)
        {
            return repositoryTypes.Get(typesId);
        }


        public string Add(Types types)
        {
            try
            {
                if (repositoryTypes.IsValid(types))
                {

                    repositoryTypes.Add(types);
                    return "OK";
                }
                else
                {
                    return "BadRequest !";
                }
            }
            catch (Exception ex)
            {

                return  ex.ToString();
            }
        }

        public string Upd(Types types)
        {
            try
            {
                if (repositoryTypes.IsValid(types))
                {
                    Types item = repositoryTypes.Get(types.TypesId);

                    if (item != null)
                    {
                        item.TypesName = types.TypesName;
                        if (repositoryTypes.Update(item))
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

        public string Del(int typesId)
        {
            try
            {

                    Types item = repositoryTypes.Get(typesId);
                    if (item != null)
                    {
                    repositoryTypes.Remove(item.TypesId);
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
