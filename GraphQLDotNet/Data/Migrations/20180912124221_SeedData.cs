using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace GraphQLDotNet.Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Items");

            migrationBuilder.AlterColumn<string>(
                name: "Barcode",
                table: "Items",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "Barcode");

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Barcode", "SellingPrice", "Title" },
                values: new object[] { "123", 50m, "Headphone" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Barcode", "SellingPrice", "Title" },
                values: new object[] { "456", 40m, "Keyboard" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Barcode", "SellingPrice", "Title" },
                values: new object[] { "789", 100m, "Monitor" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Barcode",
                keyValue: "123");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Barcode",
                keyValue: "456");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Barcode",
                keyValue: "789");

            migrationBuilder.AlterColumn<string>(
                name: "Barcode",
                table: "Items",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Items",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "Id");
        }
    }
}
