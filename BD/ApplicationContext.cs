using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace BD
{
    public class ApplicationContext : DbContext
    {

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=hellappdb;Trusted_Connection=True;");
        }

        public void Add_product(string type, double cost)
        {
            Products.Add(new Product { Type = type, Cost = cost });
            SaveChanges();
        }

        public void Delete_product(int id)
        {
            Product order = new Product { Id = id };

            Products.Attach(order);
            Products.Remove(order);
            SaveChanges();
        }

        public void Update_product(int id, string type, double cost)
        {
            Product product = new Product { Id = id };

            if (product != null)
            {
                product.Type = type;
                product.Cost = cost;

                Products.Update(product);
                SaveChanges();
            }
        }
    }
}
