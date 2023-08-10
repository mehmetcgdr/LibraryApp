using LibraryApp.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Data.Concrete.EfCore.Config
{
    public class ImageConfig : IEntityTypeConfiguration<Image>
    {
        //Kitap image'leri için Property detayları ve örnek veri girişi
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Url).IsRequired().HasMaxLength(500); //url şu an için önemli değil ama örnek olması amacıyla yazıldı.

            //Örnek veriler
            builder.HasData(
                new Image { Id = 1,  Url = "1.jpg", BookId = 1 },
                new Image {Id = 2, Url = "2.jpg", BookId = 2 },
                new Image {Id = 3, Url = "3.jpg", BookId = 3 },
                new Image {Id = 4, Url = "4.jpg", BookId = 4 },
                new Image {Id = 5, Url = "5.jpg", BookId = 5 },
                new Image {Id = 6, Url = "6.jpg", BookId = 6 },
                new Image {Id = 7, Url = "7.jpg", BookId = 7 },
                new Image {Id = 8, Url = "8.jpg", BookId = 8 },
                new Image {Id = 9, Url = "9.jpg", BookId = 9 },
                new Image {Id = 10, Url = "10.jpg", BookId = 10 },
                new Image {Id = 11, Url = "11.jpg", BookId = 11 },
                new Image {Id = 12, Url = "12.jpg", BookId = 12 }

                );
        }
    }
}