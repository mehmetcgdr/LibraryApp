using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LibraryApp.UI.Models
{
    public class LoginViewModel
    {
        [DisplayName("Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı adı boş bırakılmamalıdır")]
        public string UserName { get; set; }

        [DisplayName("Parola")]
        [Required(ErrorMessage = "Parola boş bırakılmamalıdır")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string ReturnUrl { get; set; } // Kaldığı sayfadan devam etmesi için returnUrl ile o sayfaya yönlendirme işlemi için kullanılacak.

    }
}
