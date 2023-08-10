using LibraryApp.Data.Abstract;
using LibraryApp.Data.Concrete.EfCore.Context;
using LibraryApp.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Data.Concrete.EfCore
{
    public class EfCoreBookRepository : EfCoreGenericRepository<Book>, IBookRepository
    {
        //Db için injection ve constructor iþlemi
        public EfCoreBookRepository(LibraryAppContext _appContext) : base(_appContext)
        {
        }

        LibraryAppContext AppContext
        {
            get { return _dbContext as LibraryAppContext; }
        }


        //Loan durumuna göre tüm kitaplar
        public async Task<List<Book>> GetAllBooksFullDataAsync(string categoryurl =null)
        {
            var books =AppContext.Books.OrderByDescending(x=>x.Name).Reverse()
                    .Include(b => b.Image)
                    .AsQueryable();
            if (categoryurl =="Loaned")
            {
                books = books.Where(x => x.IsOutside == true);
            }
            return await books.ToListAsync();
        }
       
        //Ýstenilen kitap
        public async Task<Book> GetBookFullDataAsync(int id)
        {
            var book = AppContext.Books.Where(x=>x.Id==id).Include(x=>x.Image).FirstOrDefault();
            return book;
        }
      
       //Yeni kitap oluþturma
        public async Task CreateBook(Book book,Image image)
        {
            await AppContext.Books.AddAsync(book);
            await AppContext.SaveChangesAsync();
            Image imageNew = new Image
            {
                BookId = book.Id,
                Url = image.Url,
            };
            
            AppContext.Images.Add(imageNew);
            await AppContext.SaveChangesAsync();
        }

      
    }
}