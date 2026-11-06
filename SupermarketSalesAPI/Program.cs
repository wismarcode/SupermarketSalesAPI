using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SupermarketSalesAPI.Data;
using SupermarketSalesAPI.DTOs.BranchDTOs;
using SupermarketSalesAPI.DTOs.CategoryDTOs;
using SupermarketSalesAPI.DTOs.ProductDTOs;
using SupermarketSalesAPI.DTOs.SaleDTOs;
using SupermarketSalesAPI.Repositories.BranchRepositories;
using SupermarketSalesAPI.Repositories.CategoryRepositories;
using SupermarketSalesAPI.Repositories.ProductRepositories;
using SupermarketSalesAPI.Repositories.SaleRepositories;
using SupermarketSalesAPI.Services.BranchServices;
using SupermarketSalesAPI.Services.CategoryServices;
using SupermarketSalesAPI.Services.ProductServices;
using SupermarketSalesAPI.Services.SaleServices;
using SupermarketSalesAPI.Validations.BranchValidations;
using SupermarketSalesAPI.Validations.CategoryValidations;
using SupermarketSalesAPI.Validations.ProductValidations;
using SupermarketSalesAPI.Validations.SaleValidations;

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
builder.Services.AddScoped<IValidator<CreateCategoryDto>, CreateCategoryValidator>();
builder.Services.AddScoped<IValidator<UpdateCategoryDto>, UpdateCategoryValidator>();
builder.Services.AddScoped<IValidator<CreateBranchDto>, CreateBranchValidator>();
builder.Services.AddScoped<IValidator<UpdateBranchDto>, UpdateBranchValidator>();
builder.Services.AddScoped<IValidator<CreateSaleDto>, CreateSaleValidator>();
builder.Services.AddScoped<IValidator<CreateSaleDetailDto>, CreateSaleDetailValidator>();
builder.Services.AddScoped<IValidator<UpdateSaleDetailDto>, UpdateSaleDetailValidator>();


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
