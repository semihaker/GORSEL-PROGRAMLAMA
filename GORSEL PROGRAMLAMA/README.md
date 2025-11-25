# PublicHolidayTracker – C# Konsol Uygulaması
Bu proje, 2023–2025 yılları arasındaki Türkiye resmi tatil bilgilerini Nager.Date API üzerinden alıp konsol ekranında çeşitli arama işlemlerine olanak sağlayan basit bir C# uygulamasıdır.
## Projenin Amacı
API'den resmi tatil verilerini HttpClient ile almak, gelen JSON verisini Holiday sınıfına dönüştürmek, uygulama açıldığında tüm yılların verilerini hafızaya almak ve menü üzerinden yıl, tarih ve isim bazlı arama işlemlerini gerçekleştirmektir.
## Kullanılan API Kaynakları
https://date.nager.at/api/v3/PublicHolidays/2023/TR  
https://date.nager.at/api/v3/PublicHolidays/2024/TR  
https://date.nager.at/api/v3/PublicHolidays/2025/TR
## Holiday Sınıfı
```csharp
public class Holiday
{
    public string date { get; set; }
    public string localName { get; set; }
    public string name { get; set; }
    public string countryCode { get; set; }

    [JsonPropertyName("fixed")]
    public bool fixed_ { get; set; }

    [JsonPropertyName("global")]
    public bool global_ { get; set; }
}
```
## Veri Yükleme Mantığı
Uygulama açıldığında 2023, 2024 ve 2025 yıllarına ait tatil verileri API’den **sadece bir kez** çekilir. Çekilen bu veriler bellekte bir liste içinde tutulur. Menü üzerinde yapılan tüm aramalar, liste üzerinde çalışır ve API’ye tekrar istek gönderilmez. Bu yapı uygulamanın daha hızlı ve stabil çalışmasını sağlar.
## Konsol Menüsü
```
===== PublicHolidayTracker =====
1. Tatil listesini göster (yıl seçmeli)
2. Tarihe göre tatil ara (gg-aa)
3. İsme göre tatil ara
4. Tüm tatilleri 3 yıl boyunca göster
5. Çıkış
Seçiminiz:
```
## Yapılabilen İşlemler
Kullanıcı yıl girerek o yıla ait resmi tatilleri görüntüleyebilir. gg-aa formatında tarih girerek tatil arayabilir. Tatil ismine göre arama yapabilir. 2023–2025 arasındaki tüm resmi tatilleri toplu halde görüntüleyebilir.
## Çalıştırma
1. Projeyi klonlayın: `git clone <repo-link>`
2. Klasöre girin: `cd PublicHolidayTracker`
3. Derleyin: `dotnet build`
4. Çalıştırın: `dotnet run`
## Geliştirici Bilgileri
