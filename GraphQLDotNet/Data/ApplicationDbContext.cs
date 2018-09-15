using GraphQLDotNet.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace GraphQLDotNet.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(e => e.Barcode);
                entity.Property(e => e.Title);
                entity.Property(e => e.SellingPrice).IsRequired();

                var items = new List<Item>
                {
                    new Item { Barcode = "123", Title = "Headphone", SellingPrice = 50 },
                    new Item { Barcode = "456", Title = "Keyboard", SellingPrice = 40 },
                    new Item { Barcode = "789", Title = "Monitor", SellingPrice = 100 }
                };

                entity.HasData(items.ToArray());
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                var customers = new List<Customer>
                {
                    new Customer { CustomerId = 1, Name = "Customer 123", BillingAddress = "123 Mainstreet" },
                    new Customer { CustomerId = 2, Name = "Customer 456", BillingAddress = "456 Mainstreet" }
                };

                entity.HasData(customers.ToArray());
            });

            modelBuilder.Entity<Order>(entity =>
            {
                var orders = new List<Order>
                {
                    new Order { OrderId = 1, Tag = "ORD-123", CreatedAt = DateTime.Now, CustomerId = 1 },
                    new Order { OrderId = 2, Tag = "ORD-456", CreatedAt = DateTime.Now, CustomerId = 2 }
                };

                entity.HasData(orders.ToArray());
            });
        }
    }
}
