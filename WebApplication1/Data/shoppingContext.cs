using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using WebApplication1.Data.Entities;

namespace WebApplication1.Data
{
    public class shoppingContext:DbContext
    {

        public shoppingContext(DbContextOptions<shoppingContext>options):base(options)
        {
           
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        //how the mapping is going to happen between ur enities and actual db 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            /*modelBuilder.Entity<Order>()
                .HasData(new Order()
                {
                    OrderNumber = "1234"  
                });*/
        }
       

    }
}
