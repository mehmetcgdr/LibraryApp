# LibraryApp
LibraryApp uygulaması kütüphane sistemlerinde kullanılan bir kitap kontrol uygulamasıdır.
Kitapların takibi ve ödünç verilmesi konularında veritabanıyla çalışarak kullanıcıya yardımcı olur.

Not:Kullanıcı girişi yapılmadan kitap ekleme, düzenleme, silme, ödünç verilme bilgileri görüntülemesi güvenlik amacıyla engellenmiştir. Login olunduğunda tüm işlevler aktif olur.

## Uygulamada Yapılabilecekler
Mevcut tüm kitapları ve ödün verilen kitapları ayrı ayrı listeleme
Yeni kitap ekleme
Kitap Düzenleme, silme
Ödünç verilen kitap geçmişi görüntüleme(Kitabın geri getirileceği değil de getirildiği tarihi yazması daha mantıklı olduğu için, kitap teslim edildiğinde veriler bu tabloya işlenir.)
Ödünç verme ve teslim alma işlemleri
Kullanıcı girişi


## Teknik Bilgiler
Proje .Net Core 7.0 ile yapılmıştır.
N Katmanlı Mimari kullanılmıştır.. Methodlar ve diğer işlemler için  Dependency Injection kullanılmıştır.
Soyut ve somut yapılar birbirlerinden ayrı klasörlerde tutulup karmaşıklıktan kaçınılmıştır.
Proje gelişime açık fakat değişime kapalı şekilde dizayn edilmiştir.

## Giriş İçin Gerekli Bilgiler
Kullanıcı Adı: admin
Şifre: 123456

## Veritabanı Bilgileri
Veritabanı olarak MsSqlServer kullanılmıştır.
Database bilgileri appSettings.json dosyasında ve Context dosyasında bulunmaktadır.(Kurulumsuz çalıştırma için Sqlite kullanımı düşünüldü fakat özellikle MsSql istenildiği için vazgeçilmiştir.)

## Kullanılan Teknolojiler
.Net Core MVC
Html
Css
BootStrap
Javascript
MsSql Server

## Paketler ve Yapılar
Identity Package
CodeFirst
EntityFramework
N Katmanlı Mimari
Repository Design Pattern
(SOLID prensipleri ve OOP dikkate alınarak uygulama tamamlanmıştır.)

## Yükleme(Installation)
İlk olarak, projeyi yerel bilgisayarınıza kopyalamak için GitHub'dan klonlayın.
Sanal Ortamı Oluşturun ve Etkinleştirin.
Uygulamayı Çalıştırın.

## Çalıştırma ve Kullanım
Öncelikle veritabanını oluşturmak için data katmanına konumlanıp terminale şu kodlar yazılır;
    dotnet ef migrations add NewMigration --startup-project ../LibraryApp.UI
bu işlem tamamlanınca;
    dotnet ef database update --startup-project ../LibraryApp.UI
Bu işlemler tamamlanınca veritabanı artık kullanıma hazırdır.

Uygulamayı local'de terminal(dotnet watch run) ya da DebugSession'da başlatın.
Başlattıktan sonra eğer internet sayfası açılmazsa http://localhost:port/ adresine gidip kullanabilirsiniz.
Açılan uygulama penceresinde kitaplar listelenir fakat login olunmadığı sürece detaylar ve diğer işlevler aktif olmayacaktır. Header kısmındaki Giriş yap butonu ile yukarıda verilen User bilgileri ile giriş yapıldığında diğer işlevler aktif olacaktır.

## Demo
![1](https://github.com/mehmetcgdr/LibraryApp/assets/43685911/821decc2-c205-4a44-b66a-74c6cefea6dd)
![2](https://github.com/mehmetcgdr/LibraryApp/assets/43685911/07f57580-c694-4699-9a97-17646b244efa)
![3](https://github.com/mehmetcgdr/LibraryApp/assets/43685911/cdef861d-51d2-4d2b-a0fb-cb7426a634c2)
![4](https://github.com/mehmetcgdr/LibraryApp/assets/43685911/a080c91d-9331-472f-9f44-520f0d0f3187)
![5](https://github.com/mehmetcgdr/LibraryApp/assets/43685911/ef3c2756-aa4b-483d-9c7a-a17b115a8c90)
![6](https://github.com/mehmetcgdr/LibraryApp/assets/43685911/7d55a739-998b-425f-ad1d-9682ea3f4d3f)
![7](https://github.com/mehmetcgdr/LibraryApp/assets/43685911/82431787-fd20-4e4a-a284-da83f0d18757)
![8](https://github.com/mehmetcgdr/LibraryApp/assets/43685911/47e5a390-4eb3-4683-a690-100dd3944595)
![9](https://github.com/mehmetcgdr/LibraryApp/assets/43685911/38d37dd5-6c5b-442a-b538-20529e3a8e7b)
![10](https://github.com/mehmetcgdr/LibraryApp/assets/43685911/f1ddf807-ad57-4822-8784-dcb607c94bad)
![11](https://github.com/mehmetcgdr/LibraryApp/assets/43685911/fa7e05dd-6c15-41bc-9ce4-79f7ccde1224)







