using LibraryApp.Entity.Entities.Identities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Data.Concrete.EfCore.Extensions
{
    //Bu builderExtension Context'i kalabalıklaştırmayıp, Context'i genişletmek için kullanıldı.
    public static class ModelBuilderExtensions
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            //Kullanıcı oluşturma, rol oluşturma, parola, rol atama işlemleri
            #region Rol Bilgileri
            
            List<Role> roles = new List<Role>//İleride eklenme ihtimalinden dolayı List yapıldı.
            {
                new Role{Name="Admin", NormalizedName="ADMIN"},
               
            };
            modelBuilder.Entity<Role>().HasData(roles);
            #endregion
            #region Kullanıcı Bilgileri
            List<User> users = new List<User>
            {
                new User{FirstName="Admin", LastName="Kitapçı", UserName="admin", NormalizedUserName="ADMIN", Email="admin@gmail.com", NormalizedEmail="ADMIN@GMAIL.COM", Gender="Erkek"}, 
            };
            modelBuilder.Entity<User>().HasData(users); 
            #endregion
            #region Parola İşlemleri
            var passwordHasher = new PasswordHasher<User>();
            users[0].PasswordHash = passwordHasher.HashPassword(users[0], "123456");
            #endregion
            #region Rol Atama İşlemleri
            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>{ UserId=users[0].Id, RoleId=roles.FirstOrDefault(r=>r.Name=="Admin").Id}
                
            };
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);
            #endregion
        }
    } 
}
