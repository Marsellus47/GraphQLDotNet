﻿// <auto-generated />
using System;
using GraphQLDotNet.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace GraphQLDotNet.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.0-preview1-35029")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("GraphQLDotNet.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BillingAddress");

                    b.Property<string>("Name");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");

                    b.HasData(
                        new { CustomerId = 1, BillingAddress = "123 Mainstreet", Name = "Customer 123" },
                        new { CustomerId = 2, BillingAddress = "456 Mainstreet", Name = "Customer 456" }
                    );
                });

            modelBuilder.Entity("GraphQLDotNet.Models.Item", b =>
                {
                    b.Property<string>("Barcode")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("SellingPrice");

                    b.Property<string>("Title");

                    b.HasKey("Barcode");

                    b.ToTable("Items");

                    b.HasData(
                        new { Barcode = "123", SellingPrice = 50m, Title = "Headphone" },
                        new { Barcode = "456", SellingPrice = 40m, Title = "Keyboard" },
                        new { Barcode = "789", SellingPrice = 100m, Title = "Monitor" }
                    );
                });

            modelBuilder.Entity("GraphQLDotNet.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CustomerId");

                    b.Property<string>("Tag");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");

                    b.HasData(
                        new { OrderId = 1, CreatedAt = new DateTime(2018, 9, 16, 10, 36, 44, 952, DateTimeKind.Local).AddTicks(6359), CustomerId = 1, Tag = "ORD-123" },
                        new { OrderId = 2, CreatedAt = new DateTime(2018, 9, 16, 10, 36, 44, 954, DateTimeKind.Local).AddTicks(3542), CustomerId = 2, Tag = "ORD-456" }
                    );
                });

            modelBuilder.Entity("GraphQLDotNet.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Barcode");

                    b.Property<int>("OrderId");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("Barcode");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");

                    b.HasData(
                        new { Id = 1, Barcode = "123", OrderId = 1, Quantity = 1 },
                        new { Id = 2, Barcode = "456", OrderId = 2, Quantity = 2 }
                    );
                });

            modelBuilder.Entity("GraphQLDotNet.Models.Order", b =>
                {
                    b.HasOne("GraphQLDotNet.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GraphQLDotNet.Models.OrderItem", b =>
                {
                    b.HasOne("GraphQLDotNet.Models.Item", "Item")
                        .WithMany("OrderItems")
                        .HasForeignKey("Barcode");

                    b.HasOne("GraphQLDotNet.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
