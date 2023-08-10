using AspNetCoreHero.ToastNotification.Abstractions;
using LibraryApp.Entity.Entities.Identities;
using LibraryApp.UI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.UI.Controllers
{
    public class AccountController : Controller
    {
        //Dependency injection ve constructor yapıldı.
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly INotyfService _notyfService;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, INotyfService notyfService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _notyfService = notyfService;
        }
        //Hesap girişi methodu
        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            //Login giriş ekranı
            return View(new LoginViewModel { ReturnUrl = returnUrl }); //Giriş yetkisi olan yere login olunmadan gidilmek istenildğinde returnUrl sayesinde login işleminden sonra kaldığı yere gidecektir.
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                //login olmaya çalışan user bilgileri veritabanından kontrol ediliyor.
                User user = await _userManager.FindByNameAsync(loginViewModel.UserName);
                if (user == null)
                {
                    _notyfService.Error("Kullanıcı bilgileri eksik ya da hatalı!");
                    return View(loginViewModel);
                }
                var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, isPersistent: true, lockoutOnFailure: true);

                if (result.Succeeded)
                {
                    _notyfService.Success("Giriş başarılı, Hoşgeldiniz :)");
                    return Redirect(loginViewModel.ReturnUrl ?? "/");//returnUrl null ya da boş ise anasayfaya gidecek
                }
                _notyfService.Error("Kullanıcı adı ya da parola hatalı!");

            }
            return View(loginViewModel);
        }

        //Hesaptan Çıkış methodu
        public async Task<IActionResult> Logout()
        {

            await _signInManager.SignOutAsync();
            _notyfService.Warning("Çıkış yapıldı!");

            return RedirectToAction("Index", "Home");
        }
    }
}
