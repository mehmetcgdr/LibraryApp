using AspNetCoreHero.ToastNotification;
using LibraryApp.Business.Concrete;
using LibraryApp.Data.Concrete.EfCore;
using LibraryApp.Business.Abstract;
using LibraryApp.Data.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using BooksApp.Business.Concrete;
using LibraryApp.Data.Concrete.EfCore.Context;
using Microsoft.AspNetCore.Identity;
using System.Data;
using LibraryApp.Entity.Entities.Identities;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
//MVC yap�s� eklendi.
builder.Services.AddControllersWithViews();
//Database Connection Context'i eklendi.
builder.Services.AddDbContext<LibraryAppContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MsSqlConnection")));

//User-Rol servisi
builder.Services.AddIdentity<User,Role>()
    .AddEntityFrameworkStores<LibraryAppContext>()
    .AddDefaultTokenProviders();

//Identity ve Sign bilgileri
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;//�ifre i�inde mutlaka rakam olmal� (-)
    options.Password.RequireLowercase = false;//�ifre i�inde mutlaka k���k harf olmal� (-)
    options.Password.RequireUppercase = false;//�ifre i�inde mutlaka b�y�k harf olmal� (-)
    options.Password.RequiredLength = 6; //Uzunlu�u 6 karakter olmal�
    options.Password.RequireNonAlphanumeric = false;//Alfan�meric olmayan karakter bar�nd�rmal� (-)
    //�rnek ge�erli parola: Qwe123.(�sttekiler a��l�rsa)

    options.Lockout.MaxFailedAccessAttempts = 3;//�st �ste izin verilecek hatal� giri� say�s� 3
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);//Kilitlenmi� hesaba 2 dakika sonra giri� yap�labilsin
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/account/login";//E�er kullan�c� eri�ebilmesi i�in login olmak zorunda oldu�u bir yere istekte bulunursa, bu sayfaya y�nlendirilecek. (account controlleri i�indeki login action�)
    options.LogoutPath = "/account/logout";//Kullan�c� logout oldu�unda bu actiona y�nlendirilecek.
    
    //Sabit Cookie
    options.Cookie = new CookieBuilder
    {
        HttpOnly = true,
        SameSite = SameSiteMode.Strict,
        Name = ".LibraryApp.Security.Cookie"
    };
});

//Dependency Injection
builder.Services.AddScoped<IBookService, BookManager>();
builder.Services.AddScoped<IBookRepository, EfCoreBookRepository>();

builder.Services.AddScoped<ILoanedService, LoanedManager>();
builder.Services.AddScoped<ILoanedRepository, EfCoreLoanedRepository>();

builder.Services.AddScoped<IImageService, ImageManager>();
builder.Services.AddScoped<IImageRepository, EfCoreImageRepository>();

//Bildirimler i�in Notyf servisi 
builder.Services.AddNotyf(config =>
{
    config.DurationInSeconds = 3;
    config.IsDismissable = true;
    config.Position = NotyfPosition.TopRight;
    config.HasRippleEffect = true;
});


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
