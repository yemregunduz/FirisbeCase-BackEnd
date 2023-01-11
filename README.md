# FirisbeCase-BackEnd
## Kullanılan Teknolojiler ve Yaklaşımlar
---
- Onion Arcitechure ile yazılmıştır.  
- Crud işlemleri EF Core 7 ile yapılmıştır. Code first ve Generic Repository Pattern yaklaşımları kullanılmıştır.  
- Mediator kütüphanesi ile CQRS dizayn pattern (db seviyesinde değil) kullanılmıştır. 
- Dinamik filtreleme mevcuttur.
- WebAPI, Swagger ile birlikte ayağa kalkmaktadır.
## Kullanım
---
Kullanımı son derece basittir. Projeyi klonladıktan sonra, MSSql kurulu olan bir bilgisayarda Visual Studio'da search kısmına package manager console yazın. Çıkan ekranı açtıktan sonra default project kısmından FirebaseCase.Persistance'ın seçili olmasına dikkat edin. Daha sonra update-database komutunu çalıştırın. Bu işlem veritabanını localinize kurmak için yeterlidir. Sonrasına projeyi WebAPI'dan ayağa kaldırarak API'ye erişim sağlayabilirsiniz. Proje https://localhost:7182/swagger/index.html portundan ayağa kalkmadıysa lütfen gerekli düzenlemeyi yapınız.

## Yazar
- Yunus Emre Gündüz
