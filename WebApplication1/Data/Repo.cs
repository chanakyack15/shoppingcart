using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data.Entities;

namespace WebApplication1.Data
{
    public class Repo : IRepo
    {
        private readonly shoppingContext ctx;

        public Repo(shoppingContext ctxx)
        { 
            this.ctx = ctxx;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return ctx.Products
                .OrderBy(p => p.Title)
                .ToList();
        }
        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return ctx.Products
                .Where(p => p.Category == category)
                .ToList();
        }
       /* public bool SaveAll() {
            return ctx.SaveChanges() > 0;
            }*/
    }
}
