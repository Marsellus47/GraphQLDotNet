﻿// <auto-generated />
using System;
using GraphQLDotNet.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace GraphQLDotNet.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180915044341_OneToManyRelationship")]
    partial class OneToManyRelationship
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                });

            modelBuilder.Entity("GraphQLDotNet.Models.Order", b =>
                {
                    b.HasOne("GraphQLDotNet.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}