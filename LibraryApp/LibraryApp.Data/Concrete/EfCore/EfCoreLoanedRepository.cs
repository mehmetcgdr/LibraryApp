using LibraryApp.Data.Abstract;
using LibraryApp.Data.Concrete.EfCore.Context;
using LibraryApp.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Data.Concrete.EfCore
{
    public class EfCoreLoanedRepository : EfCoreGenericRepository<LoanedBook>, ILoanedRepository
    {
        public EfCoreLoanedRepository(LibraryAppContext _appContext) : base(_appContext)
        {
        }

        LibraryAppContext AppContext
        {
            get { return _dbContext as LibraryAppContext; }
        }
        public async Task CreateLoanedBook(LoanedBook loanedBook)
        {
            await AppContext.LoanedBooks.AddAsync(loanedBook);
            await AppContext.SaveChangesAsync();
        }

        public async Task<List<LoanedBook>> GetAllLoanedBooks()
        {
            return await AppContext.LoanedBooks.ToListAsync();
        }


        //Eğer belirli bir ödünç alma işlemi aranacaksa isim ya da kitapId ile aranması mantıksız (birden fazla kayıt ihtimali) olacağı için bu yüzden en garanti olarak ödünç alma tarihi seçildi çünkü aynı anda kitap ödünç verme işlemi yapma ihtimali yoktur. mikrosaniye farkı ile yakalayabiliriz.
        public async Task<LoanedBook> GetByLoanedDateAsync(DateTime loanedDate)
        {
           return await AppContext.LoanedBooks.Where(x => x.LoanedDate == loanedDate).FirstOrDefaultAsync();
        }
       
    }
}
