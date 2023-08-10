using LibraryApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Business.Abstract
{
    public interface ILoanedService
    {
        Task CreateLoanedBook(LoanedBook loanedBook);
        Task<LoanedBook> GetByLoanedDateAsync(DateTime loanedDate);
        Task<List<LoanedBook>> GetAllLoanedBooks();
    }
}
