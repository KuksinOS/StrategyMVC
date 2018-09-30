using StrategyMVC.Models;
using StrategyMVC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyMVC.Controllers
{
    public class ProductsController
    {
        static readonly IRepository<Product> repositoryProducts = new ProductsRepository();

       
        public ICollection<Product> GetAll()
        {
            return repositoryProducts.GetAll();
        }

        public Product Get(int productId)
        {
            return repositoryProducts.Get(productId);
        }

        public string Add(Product products)
        {
            try
            {
                if (repositoryProducts.IsValid(products))
                {

                    repositoryProducts.Add(products);
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

        public string Upd(Product product)
        {
            try
            {
                if (repositoryProducts.IsValid(product))
                {
                    Product item = repositoryProducts.Get(product.ProductId);

                    if (item != null)
                    {
                        item.ProductName = product.ProductName;
                        if (repositoryProducts.Update(item))
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

        public string Del(int productId)
        {
            try
            {

                Product item = repositoryProducts.Get(productId);
                if (item != null)
                {
                    repositoryProducts.Remove(item.ProductId);
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
