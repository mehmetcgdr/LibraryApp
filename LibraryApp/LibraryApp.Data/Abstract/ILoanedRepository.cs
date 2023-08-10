using LibraryApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Data.Abstract
{
    public interface ILoanedRepository :IGenericRepository<LoanedBook>
    {
        Task CreateLoanedBook(LoanedBook loanedBook);
        Task<LoanedBook> GetByLoanedDateAsync(DateTime loanedDate);
        Task<List<LoanedBook>> GetAllLoanedBooks();
    }
}
