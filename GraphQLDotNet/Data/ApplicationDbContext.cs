using GraphQLDotNet.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace GraphQLDotNet.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Item> Items { get; set; }

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
        }
    }
}
