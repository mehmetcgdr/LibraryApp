using LibraryApp.Entity.Entities;

namespace LibraryApp.Data.Abstract
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Task<List<Book>> GetAllBooksFullDataAsync(string categoryurl);
        Task<Book> GetBookFullDataAsync(int id);
        Task CreateBook(Book book, Image image);
       
    }
}