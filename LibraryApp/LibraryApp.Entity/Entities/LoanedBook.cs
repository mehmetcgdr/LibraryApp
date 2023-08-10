using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Entity.Entities
{
    public class LoanedBook
    {
        //Ödünç verilen kitap entity'leri
        public int Id { get; set; }
        public string BookName { get; set; }
        public int BookId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? LoanedDate { get; set; }
        public DateTime? ReturnDate { get; set; }

    }
}
