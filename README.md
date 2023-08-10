# LibraryApp
- LibraryApp uygulaması kütüphane sistemlerinde kullanılan bir kitap kontrol uygulamasıdır.
- Kitapların takibi ve ödünç verilmesi konularında veritabanıyla çalışarak kullanıcıya yardımcı olur.

- Not:Kullanıcı girişi yapılmadan kitap ekleme, düzenleme, silme, ödünç verilme bilgileri görüntülemesi güvenlik amacıyla engellenmiştir. Login olunduğunda tüm işlevler aktif olur.

## Uygulamada Yapılabilecekler
- Mevcut tüm kitapları ve ödün verilen kitapları ayrı ayrı listeleme
- Yeni kitap ekleme
- Kitap Düzenleme, silme
- Ödünç verilen kitap geçmişi görüntüleme(Kitabın geri getirileceği değil de getirildiği tarihi yazması daha mantıklı olduğu için, kitap teslim edildiğinde veriler bu tabloya işlenir.)
- Ödünç verme ve teslim alma işlemleri
- Kullanıcı girişi


## Teknik Bilgiler
- Proje .Net Core 7.0 ile yapılmıştır.
- N Katmanlı Mimari kullanılmıştır.. Methodlar ve diğer işlemler için  Dependency Injection kullanılmıştır.
- Soyut ve somut yapılar birbirlerinden ayrı klasörlerde tutulup karmaşıklıktan kaçınılmıştır.
- Proje gelişime açık fakat değişime kapalı şekilde dizayn edilmiştir.

## Giriş İçin Gerekli Bilgiler
- Kullanıcı Adı: admin
- Şifre: 123456

## Veritabanı Bilgileri
- Veritabanı olarak MsSqlServer kullanılmıştır.
- Database bilgileri appSettings.json dosyasında ve Context dosyasında bulunmaktadır.(Kurulumsuz çalıştırma için Sqlite kullanımı düşünüldü fakat özellikle MsSql istenildiği için vazgeçilmiştir.)

## Kullanılan Teknolojiler
- .Net Core MVC
- Html
- Css
- BootStrap
- Javascript
- MsSql Server

## Paketler ve Yapılar
- Identity Package
- CodeFirst
- EntityFramework
- N Katmanlı Mimari
- Repository Design Pattern
- (SOLID prensipleri ve OOP dikkate alınarak uygulama tamamlanmıştır.)

## Çalıştırma ve Kullanım
- İlk olarak, projeyi yerel bilgisayarınıza kopyalamak için GitHub'dan klonlayın.

- Öncelikle veritabanını oluşturmak için data katmanına konumlanıp terminale şu kodlar yazılır;
 -   dotnet ef migrations add NewMigration --startup-project ../LibraryApp.UI
- bu işlem tamamlanınca;
   - dotnet ef database update --startup-project ../LibraryApp.UI
- Bu işlemler tamamlanınca veritabanı artık kullanıma hazırdır.

- Uygulamayı local'de terminal(dotnet watch run) ya da DebugSession'da başlatın.
- Başlattıktan sonra eğer internet sayfası açılmazsa http://localhost:port/ adresine gidip kullanabilirsiniz.
- Açılan uygulama penceresinde kitaplar listelenir fakat login olunmadığı sürece detaylar ve diğer işlevler aktif olmayacaktır. Header kısmındaki Giriş yap butonu ile yukarıda verilen User bilgileri ile giriş yapıldığında diğer işlevler aktif olacaktır.

## Demo
