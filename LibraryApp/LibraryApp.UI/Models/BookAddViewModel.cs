using LibraryApp.Entity.Entities;
using System.ComponentModel.DataAnnotations;

namespace LibraryApp.UI.Models
{
    public class BookAddViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Kitap adı boş bırakılmamalıdır")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Yazar adı boş bırakılmamalıdır")]
        public string Author { get; set; }
        public string Url { get; set; }
        [Required(ErrorMessage = "Kitap resmi boş bırakılmamalıdır")]
        public IFormFile Image { get; set; }

    }
}
