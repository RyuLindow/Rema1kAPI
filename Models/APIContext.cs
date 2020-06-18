using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Rema1k.Models
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Product has ONE category
            modelBuilder.Entity<Product>().HasOne(c => c.Category);
            //Product has ONE Supplier
            modelBuilder.Entity<Product>().HasOne(s => s.Supplier);
            //Category has MANY products
            modelBuilder.Entity<Category>().HasMany(p => p.Products).WithOne(a => a.Category).HasForeignKey(a => a.CategoryId);
            //Supplier has ONE category
            modelBuilder.Entity<Supplier>().HasOne(c => c.Category);
            //Supplier has MANY products
            modelBuilder.Entity<Supplier>().HasMany(p => p.Products).WithOne(a => a.Supplier).HasForeignKey(a => a.SupplierId);
            //Diagram screenshot https://i.imgur.com/5iRv4jX.png


            modelBuilder.Seed();
        }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

    }
}
