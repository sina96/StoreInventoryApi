using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StoreInventoryApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedAt", "IsActive", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 13, 13, 37, 10, 782, DateTimeKind.Utc).AddTicks(2710), true, "Laptop", 1000m, 10 },
                    { 2, new DateTime(2025, 5, 13, 13, 37, 10, 782, DateTimeKind.Utc).AddTicks(2720), true, "Mouse", 50m, 200 },
                    { 3, new DateTime(2025, 5, 13, 13, 37, 10, 782, DateTimeKind.Utc).AddTicks(2720), false, "IPod", 500m, 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
