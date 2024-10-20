# README Dosyası

## Proje Başlığı
**Konsol Tabanlı Oyun ve Hesaplama Uygulaması**

## Proje Tanımı
Bu proje, kullanıcıların eğlenceli ve öğretici bir deneyim yaşayarak çeşitli hesaplama işlemleri yapabilmelerini sağlayan bir konsol tabanlı uygulamadır. Uygulama, üç ana işlev sunmaktadır:
1. Rastgele Sayı Bulma Oyunu
2. Hesap Makinesi
3. Ortalama Hesaplama

Kullanıcılar, bu işlevleri kullanarak hem eğlenebilir hem de matematiksel becerilerini geliştirebilirler.

## Özellikler
### 1. Rastgele Sayı Bulma Oyunu
- **Amaç**: Bilgisayarın 1 ile 50 arasında rastgele seçtiği sayıyı tahmin etmek.
- **Tahmin Hakkı**: Kullanıcı, toplamda 5 tahmin hakkına sahiptir.
- **İpuçları**: Her tahminde, kullanıcıya "daha yüksek" veya "daha düşük" ipucu verilir.
- **Oyun Yenileme**: Kullanıcı, oyunun bitiminde tekrar oynamak isteyip istemediğini seçebilir.

**Kod Örneği:**
```csharp
int randomSayı = random.Next(1, 51); // 1 ile 50 arasında rastgele bir sayı seçiyoruz.
while (deneme > 0 && !tahmin)
{
    Console.Write($"Kalan tahmin hakkınız: {deneme}. Tahmininizi girin: ");
    int kullanıcıTahmin = Convert.ToInt32(Console.ReadLine());
    // İpucu verme mantığı
}
```

### 2. Hesap Makinesi
- **Temel İşlemler**: Toplama, çıkarma, çarpma ve bölme işlemleri yapılabilir.
- **Hata Kontrolü**: Kullanıcı sıfıra bölme girişiminde bulunduğunda hata mesajı gösterilir.
- **Kullanıcı Arayüzü**: Seçenekler açıkça belirtilir ve kullanıcıdan uygun giriş alınır.

**Kod Örneği:**
```csharp
char secim = Console.ReadLine()[0]; // Kullanıcının yaptığı seçimi alıyoruz.
switch (secim)
{
    case '+':
        sonuc = birinciSayı + ikinciSayı; // Toplama işlemi
        break;
    case '/':
        if (ikinciSayı == 0)
        {
            Console.WriteLine("Hata: Sıfıra bölme işlemi yapılamaz.");
        }
        else
        {
            sonuc = birinciSayı / ikinciSayı; // Bölme işlemi
        }
        break;
}
```

### 3. Ortalama Hesaplama
- **Amaç**: Kullanıcıdan üç ders notunu alarak ortalama hesaplamak.
- **Geçerlilik Kontrolü**: Girilen notların 0-100 arasında olup olmadığı kontrol edilir.
- **Harf Notu**: Hesaplanan ortalama ile birlikte kullanıcıya harf notu da gösterilir.

**Kod Örneği:**
```csharp
bool isTrue1 = double.TryParse(Console.ReadLine(), out double birinciNot);
if (isTrue1 && isTrue2 && isTrue3) // Tüm notlar geçerliyse
{
    double ortalama = (birinciNot + ikinciNot + ucuncuNot) / 3; // Ortalama hesaplama
    Console.WriteLine($"Notların ortalaması: {ortalama}"); // Ortalamayı yazdırıyoruz.
}
```

## Teknolojiler
- **Programlama Dili**: C#
- **Geliştirme Ortamı**: Visual Studio veya başka bir C# uyumlu IDE
- **Kütüphaneler**: System, System.Threading
- **Versiyon Kontrol Sistemi**: Git (önerilen)

## Kurulum
1. **Gereksinimler**: 
   - .NET Core SDK veya .NET Framework yüklü olmalıdır.
   - Visual Studio veya başka bir C# geliştirme ortamı gereklidir.
   - Gerekirse, Git yüklenmelidir.

2. **Proje Kopyalama**: Projeyi GitHub veya başka bir kaynak kontrol sisteminden kopyalayın.
   ```bash
   git clone <repo-url>
   ```

3. **Projenin Çalıştırılması**:
   - Terminal veya komut istemcisinde proje dizinine gidin.
   - Aşağıdaki komut ile projeyi çalıştırın:
   ```bash
   dotnet run
   ```

## Kullanım
1. **Ana Menü**: Uygulama çalıştığında, kullanıcıya hangi programı çalıştırmak istediği sorulur.
   ```
   Hangi programı çalıştırmak istersiniz?
   0 - Oyunu Kapatma
   1 - Rastgele Sayı Bulma Oyunu
   2 - Hesap Makinesi
   3 - Ortalama Hesaplama
   ```

2. **Oyun Seçenekleri**: Kullanıcı, aşağıdaki seçeneklerden birini seçer:
   - **0**: Programı kapatma
   - **1**: Rastgele Sayı Bulma Oyunu
   - **2**: Hesap Makinesi
   - **3**: Ortalama Hesaplama

3. **Oyunların İşleyişi**:
   - **Rastgele Sayı Bulma Oyunu**: Kullanıcı tahminlerini girer ve ipuçları alır.
   - **Hesap Makinesi**: Kullanıcıdan sayılar alınır ve seçilen işlem yapılır.
   - **Ortalama Hesaplama**: Kullanıcıdan notlar alınır ve ortalama hesaplanır.

4. **Çıkış**: Kullanıcı, "0" seçeneğini girerek uygulamadan çıkabilir.

## Geliştirme Notları
- **Kod Yapısı**: Kod, fonksiyonel programlama prensiplerine göre düzenlenmiştir. Her bir işlev, tek bir sorumluluğa sahiptir.
- **Hata Yönetimi**: Kullanıcı girişlerinin doğruluğunu kontrol etmek için `TryParse` kullanılmıştır.
- **Yenilikçi Fikirler**: Projeye eklenebilecek yeni özellikler arasında çok dilli destek, mobil uygulama versiyonu ve daha karmaşık hesaplama işlevleri bulunmaktadır.

## Test Süreci
- Uygulama, farklı senaryolar altında test edilmiştir:
  - Geçerli ve geçersiz kullanıcı girişleri.
  - Sıfıra bölme girişimleri.
  - Ortalamanın doğru hesaplanması.

## Lisans
Bu proje MIT Lisansı ile lisanslanmıştır. Daha fazla bilgi için lütfen [LICENSE](LICENSE) dosyasını kontrol edin.

## Katkıda Bulunma
Katkılarınızı bekliyoruz! Projeye katkıda bulunmak için aşağıdaki adımları izleyebilirsiniz:
1. Repo'yu forkladıktan sonra kendi branch'inizde değişiklikler yapın.
2. Değişikliklerinizi `commit` edin.
3. Pull request oluşturun.

## Gelecek Geliştirme Planları
- **Yeni Oyun Modları**: Daha fazla oyun modu eklenebilir (örneğin, matematik bulmacaları).
- **Grafik Arayüz**: Konsol uygulaması yerine grafik arayüze sahip bir versiyon geliştirilebilir.
- **Veritabanı Entegrasyonu**: Kullanıcıların geçmiş oyunlarını kaydedebileceği bir sistem eklenebilir.

