using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreInventoryApi.Migrations
{
    /// <inheritdoc />
    public partial class AddComputedColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "ALTER TABLE Products ADD COLUMN TotalStockValue DECIMAL(18,2) AS (Stock * UnitPrice) STORED");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "ALTER TABLE Products DROP COLUMN TotalStockValue");
        }
    }
}
