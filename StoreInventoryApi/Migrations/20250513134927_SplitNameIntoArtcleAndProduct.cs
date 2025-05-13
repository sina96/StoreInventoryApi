using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StoreInventoryApi.Migrations
{
    /// <inheritdoc />
    public partial class SplitNameIntoArtcleAndProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.AddColumn<string>(
                name: "ArticleName",
                table: "Products",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
            
            migrationBuilder.AddColumn<string>(
                    name: "ProductName",
                    table: "Products",
                    type: "longtext",
                    nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
            
            migrationBuilder.Sql(
                "UPDATE Products SET ArticleName = Name, ProductName =''");
            
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                    name: "Name",
                    table: "Products",
                    type: "longtext",
                    nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
            
            migrationBuilder.Sql(
                "UPDATE Products SET Name = ArticleName");
            
            migrationBuilder.DropColumn(
                name: "ArticleName",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "Products");
        }
    }
}
