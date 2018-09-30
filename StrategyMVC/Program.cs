using StrategyMVC.Controllers;
using StrategyMVC.DAL;
using StrategyMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyMVC
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //test
               TypesController typesController = new TypesController();
                typesController.Add(new Types { TypesId = 1, TypesName = "Товар" });
                typesController.Add(new Types { TypesId = 2, TypesName = "Услуга" });
                typesController.Add(new Types { TypesId = 3, TypesName = "Набор" });
                typesController.Add(new Types { TypesId = 4, TypesName = "Комплект" });

            

            SpeciesController speciesController = new SpeciesController();
            speciesController.Add(new Species { SpeciesId = 1, SpeciesName = "Продукты", Types= typesController.Get(1) });
            speciesController.Add(new Species { SpeciesId = 2, SpeciesName = "МБП", Types = typesController.Get(1) });
            speciesController.Add(new Species { SpeciesId = 3, SpeciesName = "МНМА", Types = typesController.Get(1) });
            speciesController.Add(new Species { SpeciesId = 4, SpeciesName = "Набор", Types = typesController.Get(1) });
            speciesController.Add(new Species { SpeciesId = 5, SpeciesName = "Оборудование", Types = typesController.Get(1) });
            speciesController.Add(new Species { SpeciesId = 6, SpeciesName = "Полуфабрикат", Types = typesController.Get(1) });
            speciesController.Add(new Species { SpeciesId = 7, SpeciesName = "Продукция", Types = typesController.Get(1) });
            speciesController.Add(new Species { SpeciesId = 8, SpeciesName = "Комплект", Types = typesController.Get(4) });
            speciesController.Add(new Species { SpeciesId = 9, SpeciesName = "Услуга", Types = typesController.Get(2) });


            ProductsController productsController = new ProductsController();

            Product product = new Product{ ProductId = 1, ProductName = "Картошка", ProductUnit = decimal.Parse("100,6"), Species = speciesController.Get(1) };
            productsController.Add(product);
            Product product1 = new Product { ProductId = 2, ProductName = "Запчасть до авто", ProductUnit = decimal.Parse("100,69"), Species = speciesController.Get(2) };
            productsController.Add(product1);
            Product product2 = new Product { ProductId = 3, ProductName = "Золотое кольцо", ProductUnit = decimal.Parse("100,69896"), Species = speciesController.Get(3) };
            productsController.Add(product2);

            foreach (var prod in productsController.GetAll())
            {
                prod.Display();
            }






            Console.ReadKey();
        }
    }
}
