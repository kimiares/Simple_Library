using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryProject.Models.Books;
using LibraryProject.Models.Users;


using Microsoft.EntityFrameworkCore;

namespace LibraryProject.Models.ApplicationContext
{
    public class LibraryContext: DbContext

    {

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<MyLibrary>  PersonalLibraries {get;set;}
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
     

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {




            Database.EnsureCreated();
            //Database.Migrate();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            string adminNameRole = "Admin";
            string userNameRole = "User";

            string adminEmail = "admin@gmail.com";
            string adminPassword = "321";


            Role adminRole = new Role { Id = 1, Name = adminNameRole };
            Role userRole = new Role { Id = 2, Name = userNameRole };
            User adminUser = new User { Id = 1, Email = adminEmail, Password = adminPassword, RoleId = adminRole.Id };

            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole });
            modelBuilder.Entity<User>().HasData(new User[] { adminUser });
            base.OnModelCreating(modelBuilder);

        }

    }
}
