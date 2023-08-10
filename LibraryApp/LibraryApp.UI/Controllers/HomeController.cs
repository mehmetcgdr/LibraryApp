using AspNetCoreHero.ToastNotification.Abstractions;
using BooksApp.Core;
using LibraryApp.Business.Abstract;
using LibraryApp.Entity.Entities;
using LibraryApp.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LibraryApp.UI.Controllers
{
    public class HomeController : Controller
    {
        //Dependency injection ve constructor yapıldı.
        private IBookService _bookService;
        private IImageService _imageService;
        private ILoanedService _loanedService;
        private readonly INotyfService _notyfService;

        public HomeController(IBookService bookService, IImageService imageService, INotyfService notyfService, ILoanedService loanedService)
        {
            _bookService = bookService;
            _imageService = imageService;
            _notyfService = notyfService;
            _loanedService = loanedService;
        }
        //Anasayfa --- categoryUrl eğer null ise anasayfa, eğer Loaned gelirse sadece dışarıda olan kitaplar listelenecektir.
        public async Task<IActionResult> Index(string categoryurl)
        {
            List<Book> books = await _bookService.GetAllBooksFullDataAsync(categoryurl); //tüm kitaplar
            var allBooks = await _bookService.GetAllAsync();
            var Loaneds = books.Where(x=>x.IsOutside==true).Count();

            List<BookViewModel> bookViewModels = new List<BookViewModel>();//kitap bilgileri model'a aktarılıp razor page'e geçiriliyor
            
            foreach (Book book in books)
            {
                bookViewModels.Add(new BookViewModel
                {
                   Author = book.Author,
                   FirstName = book.FirstName,
                   LastName = book.LastName,
                   LoanedDate   = book.LoanedDate,
                   ReturnDate = book.ReturnDate,
                    Id = book.Id,
                    Name = book.Name,
                    IsOutside = book.IsOutside,
                    Image = book.Image
                    
                });
            }
            //Sol sekmedeki tüm ve verilen kitap sayılarını göstermesi için ViewBag ile Count bilgisi gönderildi.
            ViewBag.AllCount = allBooks.Count();
            ViewBag.LoanedsCount = Loaneds;

            return View(bookViewModels);
        }
        //Kitap ödünç verme methodu 
        [HttpGet]
        public async Task<IActionResult> LoanTheBook(int id)
        {
            Book book =await _bookService.GetBookFullDataAsync(id);
            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> LoanTheBook(LoanViewModel loanViewModel)
        {
            //ödünç verilecek olan kitap bilgileri model'den gelen bilgiler kullanılarak bulunup ödünç verilme bilgileri dolduruluyor.
            Book book = await _bookService.GetBookFullDataAsync(loanViewModel.Id);//Kitap Id'si ile kitap bulundu.

            if (ModelState.IsValid)//eğer eksik bilgi gelirse diye kontrol işlemi yapıyoruz.
            {
            //Ödünç bilgileri dolduruldu ve kitap güncellendi.
            book.FirstName= loanViewModel.FirstName;
            book.LastName= loanViewModel.LastName;
            book.LoanedDate = DateTime.Today;
            book.ReturnDate= loanViewModel.ReturnDate;
            book.IsOutside = true;
            _bookService.Update(book);
            }
            return RedirectToAction("Index", "Home");
        }
       //Kitabı teslim alma methodu
        public async Task<IActionResult> TakeBackTheBook(int id)
        {
            
            Book book = await _bookService.GetBookFullDataAsync(id);
            
            LoanedBook loanedBook = new LoanedBook
            {
                //Bu kısımda tüm kitapların ödünç verilme geçmişinin tutulması için ayrı bir tabloya veriler kaydediliyor.
                BookId = book.Id,
                BookName=book.Name,
                FirstName = book.FirstName,
                LastName = book.LastName,
                LoanedDate = book.LoanedDate,
                ReturnDate = DateTime.Today
            };
            await _loanedService.CreateLoanedBook(loanedBook);
            //Teslim alınacak kitap, gelen Id bilgisi ile bulunup teslim almak için gereken değişiklikler veritabanına güncellenyior.
            book.FirstName = null;
            book.LastName = null;
            book.LoanedDate = null;
            book.ReturnDate = null;
            book.IsOutside = false;
            _bookService.Update(book);
            return RedirectToAction("Index", "Home");

        }
        //Yeni kitap kayıt methodu
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookAddViewModel bookAddViewModel)
        {
            //Gelen verilerin eksikliği kontrolü yapılıyor ve Kitap yaratma işlemi yapılıyor.
            if (ModelState.IsValid)
            {
                Book book = new Book
                {
                    Name = bookAddViewModel.Name,
                    Author = bookAddViewModel.Author,
                    Url = Jobs.GetUrl(bookAddViewModel.Name), //Kitap url'si ileriki seviyelerde eklenebilecek kısımlar için her ihtimale karşı tutuluyor.
                    IsOutside = false,
                    
                };
                Image image = new Image // Kitabın image bilgisi image tablosuna kaydediliyor ve kitap yaratılıyor.
                {
                    BookId=book.Id,
                    Url = Jobs.UploadImage(bookAddViewModel.Image)
                };



                await _bookService.CreateBook(book, image);
                _notyfService.Success("Kitap Ekleme başarılı:)");
                return RedirectToAction("Index");
            }
            //eğer gelen bilgilerde hata varsa tekrar denenmesi için aynı sayfaya yönlendirilip ekrana bildirim gösteriliyor.
            _notyfService.Warning("Kayıt sırasında bir hata oluştu, kontrol edip yeniden deneyiniz!");
            return View(bookAddViewModel);
        }
        //Kitap isim ve yazar güncelleme methodu
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            //İlgili kitap bulunup güncelleme işlemleri için bilgileri razor page'e gönderiliyor.
            Book book= await _bookService.GetBookFullDataAsync(id);
            BookUpdateViewModel bookUpdateViewModel = new BookUpdateViewModel
            {
                Id = book.Id,
                Name = book.Name,
                Author = book.Author,
            };
            return View(bookUpdateViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(BookUpdateViewModel bookUpdateViewModel)
        {
            if (ModelState.IsValid)
            {
                Book book = await _bookService.GetBookFullDataAsync(bookUpdateViewModel.Id); //Güncellenen kitap bulunuyor ve devamında güncelleme yapılıyor.
                if (book != null)
                {
                    book.Author = bookUpdateViewModel.Author;
                    book.Name = bookUpdateViewModel.Name;
                    book.Url = Jobs.GetUrl(bookUpdateViewModel.Name);
                    _bookService.Update(book);
                    _notyfService.Success("Güncelleme Başarılı!");
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    //Eğer kitap bulunamazsa hata bildirimi gönderiliyor.
                    _notyfService.Error("Güncelleme sırasında bir hata oluştu, kontrol edip yeniden deneyiniz!");
                    return View(bookUpdateViewModel);
                }
               
            }
            //Eğer güncelleme ekranından gelen verilerde eksiklik varsa bildirim gönderilip tekrar aynı sayfaya yönlendiriliyor.
            _notyfService.Error("Güncelleme sırasında bir hata oluştu, kontrol edip yeniden deneyiniz!");
            return View(bookUpdateViewModel);
        }

      public async Task<IActionResult> Delete(int id)
        {
            Book book = await _bookService.GetByIdAsync(id);
            if (book != null)
            {
                _bookService.Delete(book);
                _notyfService.Success("Kitap başarıyla silindi :)");
                return RedirectToAction("Index", "Home");

            }
            _notyfService.Error("Kitap silinirken bir hata oluştu!");
            return RedirectToAction("Edit", "Home", id);
        }
        //Ödünç verilen kitaplar geçmişi sayfası methodu
        public async Task<IActionResult> LoanedHistory()
        {
            List<LoanedBook> loanedBooks = await _loanedService.GetAllLoanedBooks();//Ödünç verilen tüm kitaplar veritabanından çekiliyor ve ViewModel ile razor page'e aktarılıyor.
            List<LoanedHistoryViewModel> loanedHistoryViewModels = loanedBooks.Select(x => new LoanedHistoryViewModel
            {
                BookId = x.BookId,
                BookName=x.BookName,
                FirstName = x.FirstName,
                LastName = x.LastName,
                LoanedDate = x.LoanedDate,
                ReturnDate = x.ReturnDate
            }).ToList();
            return View(loanedHistoryViewModels);
        }

    }
}