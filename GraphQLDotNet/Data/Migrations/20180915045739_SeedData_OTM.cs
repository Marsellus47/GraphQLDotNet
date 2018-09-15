using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GraphQLDotNet.Data.Migrations
{
    public partial class SeedData_OTM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "BillingAddress", "Name" },
                values: new object[] { 1, "123 Mainstreet", "Customer 123" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "BillingAddress", "Name" },
                values: new object[] { 2, "456 Mainstreet", "Customer 456" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CreatedAt", "CustomerId", "Tag" },
                values: new object[] { 1, new DateTime(2018, 9, 15, 6, 57, 39, 325, DateTimeKind.Local).AddTicks(3082), 1, "ORD-123" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CreatedAt", "CustomerId", "Tag" },
                values: new object[] { 2, new DateTime(2018, 9, 15, 6, 57, 39, 327, DateTimeKind.Local).AddTicks(1503), 2, "ORD-456" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2);
        }
    }
}
