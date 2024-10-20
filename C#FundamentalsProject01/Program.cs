using System;
using System.Threading;

public partial class Program
{
    static void Main(string[] args)
    {
        #region Giriş
        // Programın ana giriş noktasıdır.
        // Kullanıcının oyunu tekrar oynayıp oynamayacağını kontrol etmek için kullanılan bir değişken.
        // bool tekrarOyna = true;

        do
        {
            // Kullanıcıya mevcut oyun seçeneklerini gösteriyoruz.
            Console.WriteLine("Hangi programı çalıştırmak istersiniz?");
            Console.WriteLine("0 - Oyunu Kapatma");
            Console.WriteLine("1 - Rastgele Sayı Bulma Oyunu");
            Console.WriteLine("2 - Hesap Makinesi");
            Console.WriteLine("3 - Ortalama Hesaplama");

            // Kullanıcının seçim yapmasını bekliyoruz ve bu seçimi tam sayıya çeviriyoruz.
            int secim = Convert.ToInt32(Console.ReadLine());

            // Kullanıcı seçim yaptıktan sonra ekranı temizliyoruz.
            Console.Clear();

            // Kullanıcının yaptığı seçime göre ilgili işlemi başlatıyoruz.
            switch (secim)
            {
                case 0:
                    // Kullanıcı programı kapatmayı seçtiğinde, kapatma işlemi başlatılıyor.
                    Console.WriteLine("Program kapatılıyor...");
                    Thread.Sleep(1500); // 1.5 saniye bekleyerek kullanıcıya mesajı okuma süresi tanıyoruz.
                    Environment.Exit(0); // Programı sonlandırıyoruz.
                    break;
                case 1:
                    // Rastgele sayı bulma oyununu başlatıyoruz.
                    RastgeleSayı();
                    break;
                case 2:
                    // Hesap makinesi işlemini başlatıyoruz.
                    HesapMakinesi();
                    break;
                case 3:
                    // Ortalama hesaplama işlemini başlatıyoruz.
                    OrtalamaHesaplama();
                    break;
                default:
                    // Geçersiz bir seçim yapılırsa kullanıcıya hata mesajı gösteriyoruz.
                    Console.WriteLine("Geçersiz seçim, lütfen 1, 2 veya 3 girin.");
                    break;
            }

            // Kullanıcıdan oyunu tekrar oynayıp oynamak isteyip istemediğini soruyoruz.
            // Console.Write("Tekrar oynamak ister misiniz? (Evet / Hayır): ");
            // tekrarOyna = Console.ReadLine(); // Kullanıcının yanıtını alıyoruz.

        } while (true); // Kullanıcı "E" ya da "e" girdikçe döngü devam eder.

        // Program sona erdiğinde kullanıcıya bir tuşa basması için bekliyoruz.
        Console.WriteLine("Program sona erdi. Kapatılıyor...");
        Thread.Sleep(1500); // Kapatma mesajını göstermeden önce 1.5 saniye bekliyoruz.
        #endregion
    }

    #region RastgeleOyun
    // Rastgele sayı bulma oyunu fonksiyonu
    static void RastgeleSayı()
    {
        // Rastgele sayı üretimi için Random sınıfını kullanıyoruz.
        Random random = new Random();
        // 1 ile 50 arasında rastgele bir sayı seçiyoruz.
        int randomSayı = random.Next(1, 51);
        int deneme = 5; // Kullanıcının tahmin hakkı
        bool tahmin = false; // Doğru tahmin yapılıp yapılmadığını kontrol eden değişken

        // Kullanıcıya bilgi veriyoruz ve tahmin etmesini istiyoruz.
        Console.WriteLine("Bilgisayar 1 ile 50 arasında bir sayı seçti. Tahmin etmeye çalışın!");

        // Kullanıcıdan tahmin almak için döngü başlatıyoruz.
        while (deneme > 0 && !tahmin) // Kullanıcının tahmin hakkı ve doğru tahmin yapılıp yapılmadığı kontrol ediliyor.
        {
            Console.Write($"Kalan tahmin hakkınız: {deneme}. Tahmininizi girin: ");
            int kullanıcıTahmin = Convert.ToInt32(Console.ReadLine());

            // Kullanıcının tahminini doğru sayı ile karşılaştırıyoruz.
            if (kullanıcıTahmin < randomSayı)
            {
                Console.WriteLine("Daha yüksek bir sayı tahmin edin."); // Kullanıcıya ipucu veriyoruz.
            }
            else if (kullanıcıTahmin > randomSayı)
            {
                Console.WriteLine("Daha düşük bir sayı tahmin edin."); // Kullanıcıya ipucu veriyoruz.
            }
            else
            {
                tahmin = true; // Doğru tahmin yapıldı.
                Console.WriteLine("Tebrikler! Doğru tahmin ettiniz."); // Başarılı tahmini bildiren mesaj.
            }

            deneme--; // Kalan tahmin hakkını azaltıyoruz.

            // Kullanıcı tüm tahmin haklarını kaybettiğinde, durumu kontrol ediyoruz.
            if (!tahmin && deneme == 0) // Eğer doğru tahmin edilmediyse
            {
                Console.WriteLine($"Üzgünüm, tahmin hakkınız kalmadı. Doğru sayı: {randomSayı}"); // Doğru sayıyı gösteriyoruz.
                Console.WriteLine("Devam etmek ister misiniz? (E/H): ");
                string toContinue = Console.ReadLine().ToLower();

                // "e" girildiğinde oyunu tekrar başlatıyoruz.
                bool continuation = toContinue == "e";

                if (continuation)
                {
                    // Yeniden başlatma işlemi.
                    deneme = 5; // Tahmin hakkını sıfırlıyoruz.
                    tahmin = false; // Tahmin durumunu sıfırlıyoruz.
                    Console.WriteLine("Oyun yeniden başlatılıyor..."); // Yeniden başlatma mesajı.
                }
                else
                {
                    Console.WriteLine("Oyun kapatılıyor..."); // Oyun kapatma mesajı.
                }

                Thread.Sleep(1000); // 1 saniye bekleyerek kullanıcıya mesajı okuma süresi tanıyoruz.
                Console.Clear(); // Ekranı temizliyoruz.
            }
        }
    }
    #endregion

    #region OrtalamaHesaplama
    // Ortalama hesaplama fonksiyonu
    static void OrtalamaHesaplama()
    {
        bool devam = true; // Kullanıcının başka bir işlem yapmak isteyip istemediğini kontrol eden değişken.

        while (devam) // Kullanıcı devam etmek istediği sürece döngü devam eder.
        {
            // Kullanıcıdan üç ders notunu girmesini istiyoruz.
            Console.Write("Birinci ders notunu girin: ");
            bool isTrue1 = double.TryParse(Console.ReadLine(), out double birinciNot); // Notun geçerli olup olmadığını kontrol ediyoruz.

            Console.Write("İkinci ders notunu girin: ");
            bool isTrue2 = double.TryParse(Console.ReadLine(), out double ikinciNot); // Notun geçerli olup olmadığını kontrol ediyoruz.

            Console.Write("Üçüncü ders notunu girin: ");
            bool isTrue3 = double.TryParse(Console.ReadLine(), out double ucuncuNot); // Notun geçerli olup olmadığını kontrol ediyoruz.

            // Girilen notların geçerliliğini kontrol ediyoruz.
            if (isTrue1 && isTrue2 && isTrue3) // Tüm notlar geçerliyse
            {
                // Notların ortalamasını hesaplıyoruz.
                double ortalama = (birinciNot + ikinciNot + ucuncuNot) / 3;
                Console.WriteLine($"Notların ortalaması: {ortalama}"); // Ortalamayı ekrana yazdırıyoruz.
                Console.WriteLine($"Harf notu: {GetLetterGrade(ortalama)}"); // Harf notunu hesaplayıp yazdırıyoruz.
            }
            else
            {
                // Eğer notlardan biri geçerli değilse hata mesajı veriyoruz.
                Console.WriteLine("Geçersiz not girişi. Notlar 0-100 arasında olmalıdır.");
            }

            // Kullanıcıya oyunu tekrar oynamak isteyip istemediğini soruyoruz.
            Console.Write("Bu oyunu tekrar oynamak ister misiniz? (Evet/Hayır): ");
            char tekrarOyna = Console.ReadLine().ToUpper()[0]; // Kullanıcının yanıtını alıyoruz.

            if (tekrarOyna != 'E') // 'E' dışında bir değer girildiyse döngüden çıkıyoruz.
            {
                devam = false; // Devam etme durumunu false yapıyoruz.
                Console.WriteLine("Ortalama Hesaplama kapatılıyor..."); // Kapatma mesajı.
                Thread.Sleep(1000); // 1 saniye bekliyoruz.
            }

            Console.Clear(); // Ekranı temizliyoruz.
        }
    }

    // Harf notunu hesaplayan metot.
    static string GetLetterGrade(double ortalama)
    {
        // Not aralıklarına göre harf notunu belirliyoruz.
        if (ortalama >= 90) return "A"; // 90 ve üzeri için "A"
        if (ortalama >= 80) return "B"; // 80-89 arası için "B"
        if (ortalama >= 70) return "C"; // 70-79 arası için "C"
        if (ortalama >= 60) return "D"; // 60-69 arası için "D"
        return "F";
    }
    #endregion

    #region HesapMakinasıOyun
    // Hesap Makinesi fonksiyonu
    static void HesapMakinesi()
    {
        bool devam = true; // Kullanıcının başka bir işlem yapmak isteyip istemediğini kontrol eden değişken. Başlangıçta true olarak ayarlandı.

        // Kullanıcı işlemler yapmaya devam ettiği sürece döngü devam eder.
        while (devam)
        {
            // Kullanıcıdan birinci sayıyı girmesini istiyoruz.
            Console.Write("Birinci sayıyı girin: ");
            // Kullanıcının girdiği değeri double tipine çeviriyoruz ve birinciSayı değişkenine atıyoruz.
            double birinciSayı = Convert.ToDouble(Console.ReadLine());

            // Kullanıcıdan ikinci sayıyı girmesini istiyoruz.
            Console.Write("İkinci sayıyı girin: ");
            // Kullanıcının girdiği değeri double tipine çeviriyoruz ve ikinciSayı değişkenine atıyoruz.
            double ikinciSayı = Convert.ToDouble(Console.ReadLine());

            // Kullanıcıya hangi matematiksel işlemi yapmak istediğini soruyoruz.
            Console.WriteLine("Yapmak istediğiniz işlemi seçin:");
            Console.WriteLine("Toplama için +");
            Console.WriteLine("Çıkarma için -");
            Console.WriteLine("Çarpma için *");
            Console.WriteLine("Bölme için /");
            // Kullanıcının yaptığı seçimi alıyoruz.
            char secim = Console.ReadLine()[0];

            double sonuc = 0; // Hesaplanan sonucu tutmak için bir değişken tanımlıyoruz ve başlangıçta 0 olarak ayarlıyoruz.

            // Kullanıcının seçimine göre ilgili matematiksel işlemi gerçekleştiriyoruz.
            switch (secim)
            {
                case '+':
                    // Toplama işlemi
                    sonuc = birinciSayı + ikinciSayı; // Birinci ve ikinci sayıyı topluyoruz.
                    // Hesaplanan sonucu ekrana yazdırıyoruz.
                    Console.WriteLine($"Sonuç: {sonuc}");
                    break;
                case '-':
                    // Çıkarma işlemi
                    sonuc = birinciSayı - ikinciSayı; // Birinci sayıdan ikinci sayıyı çıkarıyoruz.
                    // Hesaplanan sonucu ekrana yazdırıyoruz.
                    Console.WriteLine($"Sonuç: {sonuc}");
                    break;
                case '*':
                    // Çarpma işlemi
                    sonuc = birinciSayı * ikinciSayı; // Birinci ve ikinci sayıyı çarpıyoruz.
                    // Hesaplanan sonucu ekrana yazdırıyoruz.
                    Console.WriteLine($"Sonuç: {sonuc}");
                    break;
                case '/':
                    // Bölme işlemi için sıfıra bölme kontrolü yapıyoruz.
                    if (ikinciSayı == 0)
                    {
                        // Eğer ikinci sayı sıfır ise hata mesajı veriyoruz.
                        Console.WriteLine("Hata: Sıfıra bölme işlemi yapılamaz.");
                    }
                    else
                    {
                        // Sıfıra bölme hatası yoksa bölme işlemini gerçekleştiriyoruz.
                        sonuc = birinciSayı / ikinciSayı; // Birinci sayıyı ikinci sayıya bölüyoruz.
                        // Hesaplanan sonucu ekrana yazdırıyoruz.
                        Console.WriteLine($"Sonuç: {sonuc}");
                    }
                    break;
                default:
                    // Geçersiz bir işlem girilirse hata mesajı gösteriyoruz.
                    Console.WriteLine("Geçersiz işlem. Lütfen +, -, *, / girin.");
                    break;
            }

            // Kullanıcıya başka bir işlem yapmak isteyip istemediğini soruyoruz.
            Console.Write("Başka bir işlem yapmak ister misiniz? (Evet/Hayır): ");
            // Kullanıcının yanıtını alıyoruz ve büyük harfe çeviriyoruz.
            char devamMi = Console.ReadLine().ToUpper()[0];

            // Eğer kullanıcı 'E' dışında bir yanıt verdiyse döngüden çıkıyoruz.
            if (devamMi != 'E')
            {
                devam = false; // Devam etme durumunu false yapıyoruz.
                // Kullanıcıya hesap makinesinin kapatıldığını bildiren mesaj.
                Console.WriteLine("Hesap Makinesi kapatılıyor...");
                Thread.Sleep(1500); // Kapatma mesajını göstermeden önce 1.5 saniye bekliyoruz.
            }
            Console.Clear(); // Ekranı temizliyoruz, böylece bir sonraki işlem için daha temiz bir arayüz sağlıyoruz.
        }
    }
    #endregion
}