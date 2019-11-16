using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace NovelTee.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        private DbSet<User> users;

        public DbSet<User> GetUsers()
        {
            return users;
        }

        public void SetUsers(DbSet<User> value)
        {
            users = value;
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        
        public DbSet<Color> Colors { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<TeeVariant> TeeVariants { get; set; }


        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}