using System.ComponentModel.DataAnnotations;

namespace LibraryApp.UI.Models
{
    public class LoanViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ödünç alan adı boş bırakılmamalıdır")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Ödünç alan soyadı boş bırakılmamalıdır")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Teslim tarihi boş bırakılmamalıdır")]
        public DateTime? ReturnDate { get; set; }
    }
}
