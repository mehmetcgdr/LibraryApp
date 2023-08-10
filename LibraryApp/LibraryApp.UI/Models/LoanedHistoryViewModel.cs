namespace LibraryApp.UI.Models
{
    public class LoanedHistoryViewModel
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? ReturnDate { get; set; }
        public DateTime? LoanedDate { get; set; }
    }
}
