using System;
using LibraryApp.Business.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Data.Abstract;
using LibraryApp.Entity.Entities;

namespace LibraryApp.Business.Concrete
{
    public class BookManager : IBookService
    {
        private IBookRepository _bookRepository;

        public BookManager(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task CreateBook(Book book, Image image)
        {
            await _bookRepository.CreateBook(book,image);
        }

        public void Delete(Book book)
        {
            _bookRepository.Delete(book);
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await _bookRepository.GetAllAsync();
        }

        public async Task<List<Book>> GetAllBooksFullDataAsync(string categoryurl)
        {
            return await _bookRepository.GetAllBooksFullDataAsync(categoryurl);
        }

        public async Task<Book> GetBookFullDataAsync(int id)
        {
            return await _bookRepository.GetBookFullDataAsync(id);
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _bookRepository.GetByIdAsync(id);
        }

        public void Update(Book book)
        {
            _bookRepository.Update(book);
        }
    }
}
