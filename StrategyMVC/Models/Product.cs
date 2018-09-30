using StrategyMVC.Models;
using StrategyMVC.Rounding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StrategyMVC.Models
{
    public class Product
    {
     
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductUnit { get; set; }
        public int ParentProductId { get; set; }

        public virtual Species Species { get; set; }

        protected IRounding productRounding;

        public void Display()
        {
            Console.WriteLine("Product name - {0} has Unit - {1}", ProductName, ProductUnit);
        }



        public void SetProductRounding(IRounding newproductRounding)
        {
            productRounding = newproductRounding;
        }

        public decimal Round(decimal value)
        {
           return productRounding.Rounding(value);
        }

    }
}
