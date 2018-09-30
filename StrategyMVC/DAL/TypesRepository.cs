using StrategyMVC.Models;
using StrategyMVC.Rounding;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace StrategyMVC.DAL
{
    public class TypesRepository : IRepository<Types>
    {
        
        private List<Types> types = new List<Types>();
        

        public ICollection<Types> GetAll()
        {
            return types;
        }

        public Types Get(int typesId)
        {
            return types.Find(t => t.TypesId == typesId);
        }

        public Types Add(Types item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
           // item.TypesId = types.Max(t => t.TypesId) + 1;
            types.Add(item);
            return item;
        }

        public void Remove(int typesId)
        {
            types.RemoveAll(t => t.TypesId == typesId);
        }

        public bool Update(Types item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = types.FindIndex(t => t.TypesId == item.TypesId);
            if (index == -1)
            {
                return false;
            }
            types.RemoveAt(index);
            types.Add(item);
            return true;
        }

        public bool IsValid(Types item)
        {
            return (item.TypesName != null);
        }

        
    }
}