using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThAmCo.Catering.Models
{
    public class CateringContext : DbContext
    {

        public DbSet<FoodBooking> foodBooking { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<MenuFoodItem> MenuFoodItem { get; set; }
        public CateringContext(DbContextOptions<CateringContext> options) : base(options)
        { 
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Composite Key
            builder.Entity<MenuFoodItem>()
                .HasKey(a => new { a.MenuId, a.FoodItemId });

            // Handle the many to many
            builder.Entity<MenuFoodItem>()
                .HasOne(m => m.foodItem)
                .WithMany(m => m.menuFoodItem)
                .HasForeignKey(m => m.FoodItemId);

            builder.Entity<MenuFoodItem>()
                .HasOne(m => m.Menu)
                .WithMany(m => m.menuFoodItem)
                .HasForeignKey(m => m.MenuId);

            builder.Entity<Menu>().HasData(
                new Menu { MenuId = 1, MenuName = "BBQ" },
                new Menu { MenuId = 2, MenuName = "Roast" },
                new Menu { MenuId = 3, MenuName = "Cakes" }
                );

            builder.Entity<FoodItem>().HasData(
                new FoodItem {FoodItemId = 1, Description = "Sausages", UnitPrice = 100},
                new FoodItem { FoodItemId = 2, Description = "Chicken", UnitPrice = 200 },
                new FoodItem { FoodItemId = 3, Description = "RedVelvet", UnitPrice = 300 }
                );

            builder.Entity<MenuFoodItem>().HasData(
                new MenuFoodItem { MenuId = 1, FoodItemId = 1 },
                new MenuFoodItem { MenuId = 2, FoodItemId = 2 },
                new MenuFoodItem { MenuId = 3, FoodItemId = 3 }
                );

            builder.Entity<FoodBooking>().HasData(
                new FoodBooking { FoodBookingId = 1, ClientReference = 1, NumberOfGuest = 10, MenuId = 1 },
                new FoodBooking { FoodBookingId = 2, ClientReference = 2, NumberOfGuest = 20, MenuId = 2 },
                new FoodBooking { FoodBookingId = 3, ClientReference = 3, NumberOfGuest = 30, MenuId = 3 }
                );
        }


    }
}
