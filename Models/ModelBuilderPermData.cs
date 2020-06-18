using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Rema1k.Models
{
    public static class ModelBuilderPermData
    {
        //Seed data to => APIContext line 20
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //Perm category data
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Meats", Description = "This category contains all meats", SupplierId = 1 },
                new Category { Id = 2, Name = "Vegetables", Description = "This category contains all vegetables", SupplierId = 2 },
                new Category { Id = 3, Name = "Dairy", Description = "This category contains all dairy products", SupplierId = 3 },
                new Category { Id = 4, Name = "Beverages", Description = "This category contains all beverages", SupplierId = 4 },
                new Category { Id = 5, Name = "Snacks", Description = "This category contains all snacks", SupplierId = 5 },
                new Category { Id = 6, Name = "Baked goods", Description = "This category contains all baked goods", SupplierId = 6 });

            //Perm product data
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Chicken strips", Description = "Super delicious chicken strips", Unit = "kg", Quanity = 6, Price = 35, InStock = true, CategoryId = 1, SupplierId = 1 },
                new Product { Id = 2, Name = "Ground beef", Description = "Grounded beef amazing for burgers and spaghetti", Unit = "kg", Quanity = 1, Price = 40, InStock = false, CategoryId = 1, SupplierId = 1 },
                new Product { Id = 3, Name = "Carrots", Description = "Crunchy carrots amazing for a snack", Unit = "kg", Quanity = 20, Price = 15, InStock = true, CategoryId = 2, SupplierId = 2 },
                new Product { Id = 4, Name = "Cucumber", Description = "Amazing for a salat", Unit = "quantity", Quanity = 1, Price = 7, InStock = true, CategoryId = 2, SupplierId = 2 },
                new Product { Id = 5, Name = "Milk", Description = "Delicious milk for a very well behaved cow", Unit = "liter", Quanity = 1, Price = 9, InStock = false, CategoryId = 3, SupplierId = 3 },
                new Product { Id = 6, Name = "Cheese", Description = "Pleasantly acidic, slightly sweet", Unit = "kg", Quanity = 1, Price = 25, InStock = true, CategoryId = 3, SupplierId = 3 },
                new Product { Id = 7, Name = "Carbonated water", Description = "Delicious water with bubbles", Unit = "l", Quanity = 1, Price = 6, InStock = true, CategoryId = 4, SupplierId = 4 },
                new Product { Id = 8, Name = "Apple juice", Description = "Juice freshly squeezed out from the reddest apples", Unit = "l", Quanity = 1, Price = 12, InStock = false, CategoryId = 4, SupplierId = 4 },
                new Product { Id = 9, Name = "Nacho Cheese Doritos", Description = "Bite into the cheesy goodness of Doritos® Nacho Cheese flavoured tortilla chips for a tastebud-shattering crunch", Unit = "kg", Quanity = 1, Price = 20, InStock = false, CategoryId = 5, SupplierId = 5 },
                new Product { Id = 10, Name = "Triple chocolate cookies", Description = "Delicious cookies with 3 types of chocolate", Unit = "kg", Quanity = 12, Price = 15, InStock = true, CategoryId = 5, SupplierId = 5 },
                new Product { Id = 11, Name = "Ciabata bread", Description = "Freshly baked ciabat bread", Unit = "kg", Quanity = 1, Price = 15, InStock = true, CategoryId = 6, SupplierId = 6 },
                new Product { Id = 12, Name = "Cheesecake", Description = "Super delicious cheesecake baked this morning", Unit = "kg", Quanity = 1, Price = 30, InStock = false, CategoryId = 6, SupplierId = 6 });

            //Perm supplier data
            modelBuilder.Entity<Supplier>().HasData(
                new Supplier { Id = 1, Name = "Coop", Phone = 11111111, Email = "coop@domain.com", Description = "Coop is the supplier of meat products", Delivered_before = true, CategoryId = 1 },
                new Supplier { Id = 2, Name = "Aarstiderne", Phone = 22222222, Email = "aarstiderne@domain.com", Description = "Aarstiderne is the supplier of vegetables", Delivered_before = true, CategoryId = 2 },
                new Supplier { Id = 3, Name = "Arla", Phone = 33333333, Email = "Arla@domain.com", Description = "Arla is the supplier of dairy products", Delivered_before = true, CategoryId = 3 },
                new Supplier { Id = 4, Name = "Rynkeby", Phone = 44444444, Email = "rynkeby@domain.com", Description = "Rynkeby is the supplier of beverages", Delivered_before = true, CategoryId = 4 },
                new Supplier { Id = 5, Name = "Lays", Phone = 55555555, Email = "Lays@domain.com", Description = "Lays is the supplier of snacks", Delivered_before = true, CategoryId = 5 },
                new Supplier { Id = 6, Name = "Dawnfoods", Phone = 66666666, Email = "dawnfoods@domain.com", Description = "Dawnfoods is the supplier of baked goods", Delivered_before = false, CategoryId = 6 });
        }
    }
}
