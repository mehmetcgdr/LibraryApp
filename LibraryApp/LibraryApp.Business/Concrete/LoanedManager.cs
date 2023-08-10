using LibraryApp.Business.Abstract;
using LibraryApp.Data.Abstract;
using LibraryApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Business.Concrete
{
    public class LoanedManager : ILoanedService
    {
        private ILoanedRepository _loanedRepository;

        public LoanedManager(ILoanedRepository loanedRepository)
        {
            _loanedRepository = loanedRepository;
        }

        public async Task CreateLoanedBook(LoanedBook loanedBook )
        {
            await _loanedRepository.CreateAsync(loanedBook);
        }

        public async Task<List<LoanedBook>> GetAllLoanedBooks()
        {
           return await _loanedRepository.GetAllLoanedBooks();
        }

        public async Task<LoanedBook> GetByLoanedDateAsync(DateTime loanedDate)
        {
           return await _loanedRepository.GetByLoanedDateAsync(loanedDate);
        }
    }
}
