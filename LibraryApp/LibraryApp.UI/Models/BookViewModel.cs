using LibraryApp.Entity.Entities;

namespace LibraryApp.UI.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Author { get; set; }
        public bool IsOutside { get; set; }
        public string Url { get; set; }
        public Image Image { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? LoanedDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
