using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn_EntityFramework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new MyDbContext())
            {
                // typically the context is defined in services, so when the application startups it will establish a connection to the database

                var purchase = new Purchase()
                {
                    Id = 1,
                    ProductName = "Laptop",
                    Quantity = 1,
                    Price = 1000,
                    PurchaseDate = DateTime.Now
                };

                // run CRUD operations
                context.Purchases.Add(purchase); // add the purchase to the table
                context.SaveChanges(); // save the changes to the database

                context.Purchases.Remove(purchase); // delete the purchase from the table
                context.SaveChanges(); // save the changes to the database

                context.Purchases.Update(purchase); // update the purchase in the table
                context.SaveChanges(); // save the changes to the database

                var purchaseRecord = context.Purchases.FirstOrDefault(p => p.ProductName == "Shoes"); // get the first purchase with the product name "Shoes"
                var purchaseRecord2 = context.Purchases.Where(p2 => p2.Price < 100).ToList(); // get all the purchases with a price less than 100

                // read
                var allPurchases = context.Purchases.ToList(); // get all the purchases from the table
            }
        }
    }

    public class MyDbContext : DbContext
    {
        public DbSet<Purchase> Purchases { get; set; } // this creates a table in the database

        // configure db provider
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer <-- for SQL Server (download the package: microsoftentityframeworkcore.sqlserver)
            optionsBuilder.UseInMemoryDatabase("MyDb"); // this creates a database in memory
        }
    }

    public class Purchase
    {
        // simulates a purchase table in a database
        public int Id { get; set; } // primary key
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
