using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EntityFramwork
{
    public class Program
    {
        public class NorthWindContext : DbContext
        {
            public DbSet<Category> Categories { get; set; }
            public DbSet<Product> Products { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                // configuring the class to use this specific database
                optionsBuilder.UseMySql("server=localhost;database=northwind;uid=admin;pwd=Fckfck123");
                base.OnConfiguring(optionsBuilder);
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                // mapping the objects (eg. Category) to the relevant table in the database (eg. category)
                modelBuilder.Entity<Category>().ToTable("category");
                modelBuilder.Entity<Product>().ToTable("product");

                // mapping the attributes of the object (e.g. Id) to the database columns (eg. CategoryId) in the database
                // this is required since the names are different from the objects to the database
                modelBuilder.Entity<Category>().Property(c => c.Id).HasColumnName("CategoryId");
                modelBuilder.Entity<Category>().Property(c => c.Name).HasColumnName("CategoryName");
                modelBuilder.Entity<Category>().Property(c => c.Description).HasColumnName("Ddescription");

                modelBuilder.Entity<Product>().Property(p => p.Id).HasColumnName("ProductId");
                modelBuilder.Entity<Product>().Property(p => p.Name).HasColumnName("ProductName");
                modelBuilder.Entity<Product>().Property(p => p.UnitPrice).HasColumnName("UnitPrice");

                base.OnModelCreating(modelBuilder);
            }
        }

        public static void Main(string[] args)
        {
            using (var db = new NorthWindContext())
            {
                // fetching all categories ordered by name by using the NorthWindContext with LINQ
                var categories = db.Categories.OrderBy(c => c.Name);

                foreach (var category in categories)
                {
                    Console.WriteLine($"Id: {category.Id} - Name: {category.Name} - Description: {category.Description}");
                }

                Console.WriteLine();

                // fetching all products with a UnitPrice greater than 20 ordered descending by UnitPrice
                var products = db.Products.Where(p => p.UnitPrice > 20).OrderByDescending(p => p.UnitPrice);

                foreach (var product in products)
                {
                    Console.WriteLine($"Id: {product.Id} - UnitPrice: {product.UnitPrice}");
                }
            }
        }
    }
}
