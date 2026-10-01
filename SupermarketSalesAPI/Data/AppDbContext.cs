using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupermarketSalesAPI.Models;

namespace SupermarketSalesAPI.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<SaleDetail> SaleDetails { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(category =>
            {
                category.ToTable("categories");
                category.HasKey(c => c.CategoryId);
                category.Property(c => c.Name).IsRequired().HasMaxLength(50);
                category.Property(c => c.Description).HasMaxLength(100);
            });

            modelBuilder.Entity<Product>(product =>
            {
                product.ToTable("products");
                product.HasKey(p => p.ProductId);
                product.Property(p => p.Name).IsRequired().HasMaxLength(50);
                product.Property(p => p.Price).IsRequired().HasPrecision(10,2);
                product.Property(p => p.Stock).IsRequired().HasDefaultValue(0);
                product.Property(p => p.CategoryId).IsRequired();
                product.HasOne(c => c.Category).WithMany(p => p.Product).HasForeignKey(p => p.CategoryId);
            });

            modelBuilder.Entity<Branch>(branch =>
            {
                branch.ToTable("branches");
                branch.HasKey(b => b.BranchId);
                branch.Property(b => b.Name).IsRequired().HasMaxLength(50);
                branch.Property(b => b.Address).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<Sale>(sale =>
            {
                sale.ToTable("sales");
                sale.HasKey(s => s.SaleId);
                sale.Property(s => s.SaleDate).IsRequired().HasDefaultValueSql("GETDATE()");
                sale.Property(s => s.BranchId).IsRequired();
                sale.Property(s => s.Status).IsRequired();
                sale.Property(s => s.Total).HasPrecision(10,2);
                sale.HasOne(s => s.Branch).WithMany(b => b.Sale).HasForeignKey(s => s.BranchId);

            });

            modelBuilder.Entity<SaleDetail>(detail =>
            {
                detail.ToTable("sale_details");
                detail.HasKey(d => d.SaleDetailId);
                detail.Property(d => d.SaleId).IsRequired();
                detail.Property(d => d.ProductId).IsRequired();
                detail.Property(d => d.Quantity).IsRequired();
                detail.Property(d => d.UnitPrice).IsRequired().HasPrecision(10, 2);
                detail.Property(d => d.LineTotal).IsRequired().HasPrecision(10, 2);

                detail.HasOne(d => d.Sale).WithMany(s => s.SaleDetail).HasForeignKey(d => d.SaleId);
                detail.HasOne(d => d.Product).WithMany(p => p.SaleDetail).HasForeignKey(d => d.ProductId);


            });
        }
    }
}
