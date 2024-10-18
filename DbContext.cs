using Group5_Website.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Group5_Website.Data
{
        public class AppDbContext : DbContext
       { 
            public AppDbContext(DbContextOptions<AppDbContext>options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }              // 用户表
        public DbSet<Clothes> Clothes { get; set; } // 女装表
        public DbSet<Cartitem> CartItems { get; set; }         // 购物车项

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clothes>().HasKey(c => c.item_Id); // 配置主键

            modelBuilder.Entity<Cartitem>().HasKey(ci => ci.CartItemId); // 配置 CartItem 的主键
            modelBuilder.Entity<Cartitem>().HasOne(i => i.Product)         // 每个 CartItem 有一个 Product
                .WithMany()                     // 可有多个 CartItem
                .OnDelete(DeleteBehavior.Cascade); // 级联删除行为（根据需要）




            modelBuilder.Entity<Manager>().HasData(
                new Manager { Id = 1, Account = "gp5", Password = "123456" }
                );

            modelBuilder.Entity<User>().HasData(
               new User { Id = 1, Account = "panxiyi", Password = "123456" }
               );


            modelBuilder.Entity<Clothes>().HasData(
                new Clothes { item_Id = 1, item_Name = "Lilac Flex Hoodie", item_Category = "Upper-Body", item_Description = "A stylish, lightweight sweatshirt in a soft light purple hue. Perfect for casual outings or post-workout comfort with a relaxed fit.",
                item_Imageurl = "", item_Price = 39.99m, item_Size = "Default", item_Type = "Female" },
                new Clothes { item_Id = 2, item_Name = "Monochrome Edge", item_Category = "Footwear", item_Description = "A dynamic blend of black, white, and gray hues, these shoes offer both fashion and functionality, ideal for gym sessions or everyday activities.", 
                item_Imageurl = "", item_Price = 55.49m, item_Size = "Default", item_Type = "Female" },
                new Clothes { item_Id = 3, item_Name = "Flex-fit Joggers", item_Category = "Lower-Body", item_Description = "These dark, loose-fit pants provide all-day comfort and flexibility, perfect for casual wear or light exercise.",
                item_Imageurl = "", item_Price = 29.99m, item_Size = "Default", item_Type = "Female" },
                new Clothes { item_Id = 4, item_Name = "Comfort Grey Tee", item_Category = "Upper-Body", item_Description = "This relaxed-fit gray tee provides a stylish look with full coverage, perfect for workouts or casual outings.",
                item_Imageurl = "", item_Price = 19.99m, item_Size = "Default", item_Type = "Female" },
                new Clothes { item_Id = 5, item_Name = "Pure-Sun Cap", item_Category = "Headwear", item_Description = "This stylish white cap combines functionality with elegance, providing sun protection while keeping you cool during outdoor activities.",
                item_Imageurl = "", item_Price = 14.99m, item_Size = "Default", item_Type = "Female" },
                new Clothes { item_Id = 6, item_Name = "Dual-tone Jacket", item_Category = "Upper-Body", item_Description = "This stylish black and blue outerwear features a modern design, providing warmth and versatility for any active lifestyle.", 
                item_Imageurl = "", item_Price = 49.99m, item_Size = "Default", item_Type = "Male" },
                new Clothes { item_Id = 7, item_Name = "Breeze Cap", item_Category = "Headwear", item_Description = "This white cap features blue accents and a pink trim, combining style and functionality for sunny workouts and casual outings.", 
                item_Imageurl = "", item_Price = 15.99m, item_Size = "Default", item_Type = "Male" },
                new Clothes { item_Id = 8, item_Name = "Aqua-speed Tee", item_Category = "Upper-Body", item_Description = "This deep blue short sleeve shirt combines style and performance, perfect for workouts or casual outings with breathable fabric for ultimate comfort.", 
                item_Imageurl = "", item_Price = 22.99m, item_Size = "Default", item_Type = "Male" },
                new Clothes { item_Id = 9, item_Name = "Easy-move Trousers", item_Category = "Lower-Body", item_Description = "These gray, relaxed-fit pants feature an elastic waistband for ultimate comfort, ideal for workouts or lounging.", 
                item_Imageurl = "", item_Price = 34.99m, item_Size = "Default", item_Type = "Male" },
                new Clothes { item_Id = 10, item_Name = "Gradient Glide Trainers", item_Category = "Footwear", item_Description = "These lightweight trainers showcase a stylish black-to-white gradient, designed with soft rubber soles for ultimate cushioning and support during any activity.", 
                item_Imageurl = "", item_Price = 59.99m, item_Size = "Default", item_Type = "Male" }
            );
        }
    }
    

}
