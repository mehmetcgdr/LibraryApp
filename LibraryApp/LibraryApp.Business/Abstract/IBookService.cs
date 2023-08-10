using LibraryApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Business.Abstract
{
    public interface IBookService
    {
        Task CreateBook(Book book,Image image);
        Task<Book> GetByIdAsync(int id);
        Task<List<Book>> GetAllAsync();
        void Update(Book book);
        void Delete(Book book);
        Task<List<Book>> GetAllBooksFullDataAsync(string categoryurl=null);
        Task<Book> GetBookFullDataAsync(int id);
    }
}
