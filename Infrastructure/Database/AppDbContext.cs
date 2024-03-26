using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductId);
                entity.Property(e => e.ProductId).ValueGeneratedOnAdd();
                entity.Property(e => e.Description).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Status).IsRequired().HasMaxLength(10);
                entity.Property(e => e.ManufactureDate).IsRequired();
                entity.Property(e => e.ExpiryDate).IsRequired();
                entity.Property(e => e.SupplierCode).IsRequired();
                entity.Property(e => e.SupplierName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.SupplierDescription).IsRequired().HasMaxLength(100);
                entity.Property(e => e.SupplierCNPJ).IsRequired().HasMaxLength(14);

                entity.HasIndex(e => new { e.Description, e.SupplierCode }).IsUnique();

            });

        }

    }
}
