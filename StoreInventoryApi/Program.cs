using Microsoft.EntityFrameworkCore;
using StoreInventoryApi.Data;
using StoreInventoryApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 36))
    ));
    
builder.Services.AddScoped<IProductService, ProductService>();
