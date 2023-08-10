using LibraryApp.Data.Concrete.EfCore.Config;
using LibraryApp.Data.Concrete.EfCore.Extensions;
using LibraryApp.Entity;
using LibraryApp.Entity.Entities;
using LibraryApp.Entity.Entities.Identities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace LibraryApp.Data.Concrete.EfCore.Context
{
    public class LibraryAppContext : IdentityDbContext<User,Role,string>
    {
        //DbContext constructor
        public LibraryAppContext(DbContextOptions options) : base(options)
        {
        }
        //Oluþturulacak tablolar
        public DbSet<Book> Books { get; set; } 
        public DbSet<LoanedBook> LoanedBooks { get; set; }
        public DbSet<Image> Images { get; set; }

        //Sql Connection String
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-9DK14MA\\SQLEXPRESS01;Database=LibraryAppDb;User Id=sa;Password=123;TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedData();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookConfig).Assembly); //BookConfig'in olduðu klasördeki diðer dosyalar için de uygulasýn diye Apply'ledik.
            base.OnModelCreating(modelBuilder);
        }

    }
}