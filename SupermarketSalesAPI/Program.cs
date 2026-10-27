using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SupermarketSalesAPI.Data;
using SupermarketSalesAPI.DTOs.ProductDTOs;
using SupermarketSalesAPI.Repositories.BranchRepositories;
using SupermarketSalesAPI.Repositories.CategoryRepositories;
using SupermarketSalesAPI.Repositories.ProductRepositories;
using SupermarketSalesAPI.Repositories.SaleRepositories;
using SupermarketSalesAPI.Services.BranchServices;
using SupermarketSalesAPI.Services.CategoryServices;
using SupermarketSalesAPI.Services.ProductServices;
using SupermarketSalesAPI.Services.SaleServices;
using SupermarketSalesAPI.Validations.ProductValidations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection"));
});

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IBranchRepository, BranchRepository>();
builder.Services.AddScoped<IBranchService, BranchService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ISaleRepository, SaleRepository>();
builder.Services.AddScoped<ISaleService, SaleService>();


builder.Services.AddScoped<IValidator<CreateProductDto>, CreateProductValidator>();
builder.Services.AddScoped<IValidator<UpdateProductDto>, UpdateProductValidator>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
