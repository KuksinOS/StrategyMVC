using StrategyMVC.Models;
using StrategyMVC.Rounding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyMVC.DAL
{
    public class ProductsRepository : IRepository<Product>
    {
        private List<Product> products = new List<Product>();

      
        public ICollection<Product> GetAll()
        {
            return products;
        }

        public Product Get(int productId)
        {
            return products.Find(t => t.ProductId == productId);
        }

        public Product Add(Product item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            //item.ProductId = products.Max(p => p.ProductId) + 1;

            if (item.Species.SpeciesId == 1 && item.Species.Types.TypesId == 1)
            {
                item.SetProductRounding(new MRounding());
                item.ProductUnit = item.Round(item.ProductUnit);
            }
            else if (item.Species.SpeciesId == 2 && item.Species.Types.TypesId == 1)
            {
                item.SetProductRounding(new BRoundingTo1());
                item.ProductUnit = item.Round(item.ProductUnit);
            }
            else if (item.Species.SpeciesId == 3 && item.Species.Types.TypesId == 1)
            {
                item.SetProductRounding(new BRoundingTo3());
                item.ProductUnit = item.Round(item.ProductUnit);
            }
            products.Add(item);
            return item;
        }

        public void Remove(int productId)
        {
            products.RemoveAll(t => t.ProductId == productId);
        }

        public bool Update(Product item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = products.FindIndex(t => t.ProductId == item.ProductId);
            if (index == -1)
            {
                return false;
            }
            products.RemoveAt(index);
            products.Add(item);
            return true;
        }

        public bool IsValid(Product item)
        {
            return (item.ProductName != null);
        }

    }
}
