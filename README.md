# StoreInventoryApi

An ASP.NET Core Web API that showcases advanced usage of **Entity Framework Core** with a **MySQL database**, using **code-first migrations**, **relationships**, **computed fields**, **projections**, and other real-world features.

This project is structured as a backend system for managing a store's product inventory. It demonstrates clean architecture with a service layer, DTO projections for performance, and progressive database evolution via well-documented migrations.

---

## 🚀 Technologies

- ASP.NET Core Web API (.NET 8)
- Entity Framework Core (Code-First)
- MySQL (via Pomelo EF Provider)
- JetBrains Rider IDE
- MySQL Workbench (DB management)
- LINQ / Async Queries
- DTO Projections
- Fluent API Configurations

---

## 📜 Migration History

| Migration | Description |
|-----------|-------------|
| `InitialCreate` | Created initial `Product` table |
| `AddCategory` | Introduced one-to-many `Product → Category` |
| `RemoveProductDescription` | Removed obsolete `Description` field |
| `AddCreatedAtToProduct` | Added `CreatedAt` timestamp to products |
| `RemoveCategory` | Dropped the `Category` table |
| `AddIsActiveToProduct` | Added soft delete (`IsActive`) flag |
| `AddProductReview` | Added one-to-many `Product → ProductReview` |
| `AddUniqueConstraintToProductName` | Enforced uniqueness on `ProductName` |
| `SeedInitialProducts` | Seeded test products |
| `RenamePriceToUnitPrice` | Renamed `Price` to `UnitPrice` |
| `SplitNameIntoArtcleAndProduct` | Replaced `Name` with `ArticleName` and `ProductName` |
| `AddComputedColumn` | Added a generated column for total stock value (`Stock * UnitPrice`) |
| `AddAuditTable` | Created a manual audit table using raw SQL |
| `AddSupplierWithNullableFk` | Added `Supplier` entity with owned `Address` and FK from `Product` (nullable) |

---

## 🧠 Concepts Demonstrated

- DTO-based data shaping via `.Select()` projection
- Owned entities (`Address` inside `Supplier`)
- One-to-many and optional relationships
- Schema refactoring through reversible migrations
- Seed data and relationships with `HasData`
- Computed/generated columns in MySQL
- Manual data transformation in migrations
- Clean architecture (services vs controllers)

---

## 📮 API Examples

- `GET /api/products/projected` – Returns lean product data using DTOs
- `GET /api/products/with-reviews` – Returns products with their reviews
- `POST /api/products` – Create a new product
- `DELETE /api/products/{id}` – Soft delete via `IsActive = false`

---

## 🧪 How to Run

1. Configure MySQL and create a `store_db` database.
2. Update connection string in `appsettings.json` or `Program.cs`.
3. Run migrations:

```bash
dotnet ef database update
```
