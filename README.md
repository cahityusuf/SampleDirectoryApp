# SampleDirectoryApp

# KULLANILAN TEKNOLOJİLER
1.  RabbitMQ
2.  Postgresql
3.  .Net 5.0
4.  Swagger

# MIGRATIN ISLEMLERİ
1.  Migration: Appsettings.Json dosyasında, "ConnectionStrings:DirectoryDbContext" dizininde bulunan Connectionstring'te bulunan "Database" ve "Password" bilgileri önemlidir.
"Database" adı => DirectoryDb olarak belirlenmiştir.
2.  Password => localinizde kurulu olan postgresql databasine bağlandığınız şifredir. Her kişide farklılık gösterdiğinden boş bırakıyorum.Lütfen kendi şifrenizi giriniz.
3.  bu işlemden sonra "Update-Database" komutu ile tablolarınızı oluşturabilirsiniz.

# SAMPLE DATA
1.  Oluşturduğum veri tabanına giriş yaptığım örnek birkaç datanın SQL INSERT çıktıları ve DUMP dosyası Repoya eklenmiştir.

# GİT İŞLEMLERİ
1.  DirectoryApp isminde branc oluşturularak geliştirme yapılmıştır. 
2.  Yapılan geliştirmeler Pull-Request isteği oluşturularak Main branci ile Marge edilmiştir.

# AÇIKLAMA
1.  Assessment içeriğinden anladıklarıma istinaden, 3 adet tablo oluşturum.
2.  User Tablosu, Kullanıcı bilgileri tutar.
3.  ContactInfo Tablosu, User tablosunda kayıtlı kişilere ait iletişim bilgilerini tutar.
4.  ContactType Tablosu, ContactInfo tablosunda kaydettiğimiz iletişim tiplerini tutar. (Telefon,Email,Konum)
5.  Yukarıda tanımlanan tabloların CRUD işlemlerine ait endpointler tanımlanmıştır.
6.  Listeleme işlemleri sırasında bilgileri Joinli gelerek tüm ilişki tabloları doldurulmuştur.
7.  Böylelikler çağrılan kişiley ait iltişim bilgileride dolmaktadır.
8.  DirectoryWorkerService ve ReportingService ile hiçbir bağlantısı yoktur.
9.  Sadece rehbere veri kayıdı için kullanılır.
