using System.ComponentModel.DataAnnotations;

namespace LibraryApp.UI.Models
{
    public class BookUpdateViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Kitap adı boş bırakılmamalıdır")] //Eğer boş bırakılırsa uyarı verilecek
        public string Name { get; set; }
        [Required(ErrorMessage = "Yazar adı boş bırakılmamalıdır")]
        public string Author { get; set; }
    }
}
