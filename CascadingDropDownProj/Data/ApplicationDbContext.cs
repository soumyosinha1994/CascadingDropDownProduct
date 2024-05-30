using CascadingDropDownProj.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Mono.TextTemplating;
using System.Diagnostics.Metrics;

namespace CascadingDropDownProj.Data
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(new Category { CategoryName = "Mobiles", Id = 1 },
            new Category { CategoryName = "Laptops", Id = 2 });

            modelBuilder.Entity<SubCategory>().HasData(new SubCategory { Id = 1, SubCategoryName = "iPhone", CategoryId = 1 },
                new SubCategory { Id = 2, SubCategoryName = "HP", CategoryId = 2 });

            modelBuilder.Entity<Product>().HasData(new Product { Id = 1, ProductName = "iPhone 15", SubCategoryId = 1 },
                new Product { Id = 2, ProductName = "Pro Book", SubCategoryId = 2 });
        }
    }
}
