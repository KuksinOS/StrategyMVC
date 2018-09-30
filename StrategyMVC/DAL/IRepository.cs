using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyMVC.DAL
{
   public interface IRepository<T>
         where T : class
    {

        ICollection<T> GetAll();
        T Get(int Id);
        T Add(T item);
        void Remove(int Id);
        bool Update(T item);
        bool IsValid(T item);

    }
}
