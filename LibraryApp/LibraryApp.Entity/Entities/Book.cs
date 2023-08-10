

namespace LibraryApp.Entity.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Author { get; set; }
        public bool IsOutside { get; set; }
        public string Url { get; set; }
        public Image Image { get; set; }
        public string? FirstName { get; set; } //Teslim alan kiþi adý
        public string? LastName { get; set; } //Teslim alan kiþi soyadý
        public DateTime? LoanedDate { get; set; }  //Ödünç verilme tarihi
        public DateTime? ReturnDate { get; set; } //Teslim alma tarihi

    }
}