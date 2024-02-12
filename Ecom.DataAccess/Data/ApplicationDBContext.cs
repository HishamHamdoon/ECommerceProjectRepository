using Ecom.Models.Models;
using ECommerceProject.Ecom.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ECommerceProject.Ecom.DataAccess.Data
{
	public class ApplicationDBContext:IdentityDbContext<IdentityUser>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        //public override void Execute(Microsoft.EntityFrameworkCore.Storage.IRelationalConnection connection);
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            

            modelBuilder.Entity<Category>().HasData(
               new Category { Id = 1, Name = "Category of Clothes", DisplayOrder = 1 },
               new Category { Id = 2, Name = "Category of Shooses", DisplayOrder = 2 },
               new Category { Id = 3, Name = "Category of Mobiles", DisplayOrder = 3 },
               new Category { Id = 4, Name = "Category of Accesories", DisplayOrder = 4 },
               new Category { Id = 5, Name = "Category of Accesories", DisplayOrder = 4 },
               new Category { Id = 6, Name = "Category of Accesories", DisplayOrder = 4 }
               );
            modelBuilder.Entity<Company>().HasData(
   new Company
   {
       Id = 1,
       Name = "Hamdon Company",
       StreetAddress = "King Fahd Road",
       City = "Riyadh",
       State = "Riyadh",
       PostalCode = "123 RUH",
       PhoneNumber = "0235403354555"
   },
   new Company
   {
                Id = 2,
       Name = "Hamdon Company1",
       StreetAddress = "King Fahd Road",
       City = "Riyadh",
       State = "Riyadh",
       PostalCode = "123 RUH",
       PhoneNumber = "0235403354555"
   }
   );

           modelBuilder.Entity<Product>().HasData(
    new Product
    {
        Id = 1,
        Author = "Hisham",
        Title = "C# for beginners",
        Description = "this is a C# book",
        ISBN = "ASDCV456"
    ,
        ListPrice = 88,
        Price = 100,
        Price100 = 55,
        Price50 = 90,
        CategoryId = 5,
        ImageUrl = ""
    },
    new Product
    {
        Id = 7,
        Author = "Hisham",
        Title = "C# for beginners",
        Description = "this is a C# book",
        ISBN = "ASDCV456",
        ListPrice = 88,
        Price = 100,
        Price100 = 55,
        Price50 = 90,
        CategoryId = 6,
        ImageUrl = ""
    },
    new Product
    {
        Id = 2,
        Author = "Obai",
        Title = "dornet for beginners",
        Description = "this is a Cdotnet book in pdf",
        ISBN = "ASDCV4564566",
        ListPrice = 88,
        Price = 100,
        Price100 = 55,
        Price50 = 90,
        CategoryId = 5,
        ImageUrl = ""
    },
    new Product
    {
        Id = 3,
        Author = "Ahmed",
        Title = "C++ for beginners",
        Description = "this is a C++ book for beginners",
        ISBN = "ASDCV456",
        ListPrice = 88,
        Price = 100,
        Price100 = 55,
        Price50 = 90,
        CategoryId = 6,
        ImageUrl = ""
    },
    new Product
    {
        Id = 4,
        Author = "Ali",
        Title = "F# for beginners",
        Description = "this is a F# book for beginners",
        ISBN = "ASDCV4asdf56",
        ListPrice = 88,
        Price = 100,
        Price100 = 55,
        Price50 = 90,
        CategoryId = 5,
        ImageUrl = ""
    },
    new Product
    {
        Id = 5,
        Author = "Musa",
        Title = "PHP for beginners",
        Description = "this is a PHP book for beginners",
        ISBN = "ASDCV456884513",
        ListPrice = 88,
        Price = 55,
        Price100 = 150,
        Price50 = 66,
        CategoryId = 6,
        ImageUrl = ""
    },
    new Product
    {
        Id = 6,
        Author = "Ahmed Taha",
        Title = "Media for beginners",
        Description = "this is a Media book for beginners",
        ISBN = "ASDCV4sd2356",
        ListPrice = 50,
        Price = 45,
        Price100 = 22,
        Price50 = 10,
        CategoryId = 5,
        ImageUrl = ""
    }
    );
        }
      
    
    }
}
