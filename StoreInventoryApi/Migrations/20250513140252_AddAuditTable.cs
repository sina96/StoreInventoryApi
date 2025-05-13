using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreInventoryApi.Migrations
{
    /// <inheritdoc />
    public partial class AddAuditTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.Sql(
                @"CREATE TABLE ProductAuditLog (
                Id INT PRIMARY KEY AUTO_INCREMENT,
                ProductId INT NOT NULL,
                ChangedAt DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
                ChangeSummary TEXT
    )");


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TABLE ProductAuditLog");
        }
    }
}
