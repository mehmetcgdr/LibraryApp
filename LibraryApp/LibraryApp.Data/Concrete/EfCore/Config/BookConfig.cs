using LibraryApp.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Security.Cryptography.X509Certificates;

namespace LibraryApp.Data.Concrete.EfCore.Config
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        //Kitap için Property detayları ve örnek veri girişi
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd(); //Id otomatik kendi oluşturacak ve arttıracak.

            builder.Property(x => x.Name).IsRequired().HasMaxLength(100); //Kitap ismi zorunlu ve maks 100 karakter
            
            //Örnek veriler
            builder.HasData(
                new Book { Id = 1,  IsOutside = false, Name = "Fahrenheit 451", Url="fahrenheit-451", Author="Ray Bradbury" },
                new Book { Id = 2,  IsOutside = false, Name = "Kadınlar Ülkesi",  Url="kadinlar-ulkesi",Author= "Charlotte Perkin Stetson" },
                new Book { Id = 3,  IsOutside = false, Name = "İnsanlar", Url="insanlar",Author="Matt Haig" },
                new Book { Id = 4,  IsOutside = false, Name = "Görünmez Adam", Url="gorunmez-adam",Author= "Herbert George Wells" },
                new Book { Id = 5,  IsOutside = false, Name = "Siyah Günce", Url="siyah-gunce" ,Author= "Mücahit Gezen" },
                new Book { Id = 6,  IsOutside = false, Name = "Nebo'nun Mavi Kitabı", Url="nebonun-mavi-kitabi",Author= "Manon Steffan Ros" },
                new Book { Id = 7,  IsOutside = false, Name = "Evrenin Sonundaki Restoran", Url="evrenin-sonundaki-restoran",Author= "Douglas Adams" },
                new Book { Id = 8,  IsOutside = false, Name = "Beni Kim Öldürdü?", Url="beni-kim-oldurdu",Author= "Burcu Arman" },
                new Book { Id = 9,  IsOutside = false, Name = "Zihin Kütüphanesi", Url="zihin-kutuphanesi",Author= "Anıl Şahal" },
                new Book { Id = 10, IsOutside = false, Name = "Yeni Bir Yaşam", Url="yeni-bir-yasam",Author= "Alexandra Monir" },
                new Book { Id = 11, IsOutside = false, Name = "Gecenin Kraliçesi", Url="gecenin-kralicesi",Author= "Aysegül Yildiz" },
                new Book { Id = 12, IsOutside = false, Name = "Efendi Uyanıyor", Url="efendi-uyaniyor",Author= "Herbert George Wells" }
            );
        }
    }
}