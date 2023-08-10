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
//MVC yapýsý eklendi.
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
    options.Password.RequireDigit = false;//Þifre içinde mutlaka rakam olmalý (-)
    options.Password.RequireLowercase = false;//Þifre içinde mutlaka küçük harf olmalý (-)
    options.Password.RequireUppercase = false;//Þifre içinde mutlaka büyük harf olmalý (-)
    options.Password.RequiredLength = 6; //Uzunluðu 6 karakter olmalý
    options.Password.RequireNonAlphanumeric = false;//Alfanümeric olmayan karakter barýndýrmalý (-)
    //Örnek geçerli parola: Qwe123.(üsttekiler açýlýrsa)

    options.Lockout.MaxFailedAccessAttempts = 3;//Üst üste izin verilecek hatalý giriþ sayýsý 3
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);//Kilitlenmiþ hesaba 2 dakika sonra giriþ yapýlabilsin
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/account/login";//Eðer kullanýcý eriþebilmesi için login olmak zorunda olduðu bir yere istekte bulunursa, bu sayfaya yönlendirilecek. (account controlleri içindeki login actioný)
    options.LogoutPath = "/account/logout";//Kullanýcý logout olduðunda bu actiona yönlendirilecek.
    
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

//Bildirimler için Notyf servisi 
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
