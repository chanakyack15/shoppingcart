using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WebApplication1.Data.Entities;

namespace WebApplication1.Data
{
    public class WebApplicationSeeder
    {
        private readonly shoppingContext ctx;

        public WebApplicationSeeder(shoppingContext _ctx ,  IHostingEnvironment hosting)
        {
            ctx = _ctx;
            Hosting = hosting;
        }

        public IHostingEnvironment Hosting { get; }

        public void seed(){

            ctx.Database.EnsureCreated();
            //it ensure that database is exist before connecting 

            if (!ctx.Products.Any())
            {
                //it will return false if any products in the db

                var filepath = Path.Combine(Hosting.ContentRootPath, "Data/shopping.json");
                var json = File.ReadAllText(filepath);
                var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);
                ctx.Products.AddRange(products);
                var order = ctx.Orders.Where(o => o.Id == 1).FirstOrDefault();
                if (order != null) {
                    order.Items = new List<OrderItem>()
                    {
                        new OrderItem()
                        {
                            Product = products.First(),
                            Quantity = 5,
                            UnitPrice = products.First().Price

                        }
                    };
                }

                ctx.SaveChanges();
            }
          /*  else
            {
              
                // need to create data 
            }*/
        }
    }
}
