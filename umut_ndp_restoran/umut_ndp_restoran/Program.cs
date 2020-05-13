/****************************************************************************
**                  SAKARYA ÜNİVERSİTESİ
**                  BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**                  BİLİŞİM SİSTEMLERİ MÜHENDİSLİĞİ BÖLÜMÜ
**                  NESNEYE DAYALI PROGRAMLAMA DERSİ
**                  2019-2020 BAHAR DÖNEMİ
**
**                  PROJE NUMARASI.........: 01
**                  ÖĞRENCİ ADI............: Umutcan Çakırcı
**                  ÖĞRENCİ NUMARASI.......: B171200054
**                  DERSİN ALINDIĞI GRUP...: A
****************************************************************************/



using System;
using System.Collections.Generic;
using System.Linq;

namespace umut_ndp_restoran
{
    class Program
    {
        // Restoranımızdaki bütün masaları tuttuğumuz masalar listesi
        static List<Masa> masalar = new List<Masa>();
        // Bütün rezervasyonların tutulduğu liste
        static List<Rezervasyon> rezervasyonlar = new List<Rezervasyon>();
        // Restoranımızdaki masaları oluşturan fonksiyon
        static void masalariOlustur() {
            Masa masa1 = new Masa(1, 4);
            Masa masa2 = new Masa(2, 2);
            Masa masa3 = new Masa(3, 2);
            Masa masa4 = new Masa(4, 4);
            Masa masa5 = new Masa(5, 4);
            Masa masa6 = new Masa(6, 6);
            masalar.Add(masa1);
            masalar.Add(masa2);
            masalar.Add(masa3);
            masalar.Add(masa4);
            masalar.Add(masa5);
            masalar.Add(masa6);

        }

        // yeni bir rezervasyon oluşturulduğunda bu rezervasyonun uygun olup olmadığı kontrol ediyoruz.
        static bool kontrolEt(int masaNumarasi, DateTime baslangicTarihi, DateTime bitisTarihi) {
            // müşteri tarafından bize beliritlen tarihte daha önce bir rezervasyon yapılmış mı 
            // diye kontrol edilip eğer eşleşen bir sonuç bulunmaduysa Fonksiyon true değeri döner
            // fakat çakışan bir şey varsa false değeri döner ki bu da rezervasyonun mümkün olamayacağının
            // bir göstergesidir.
            Rezervasyon rez = rezervasyonlar.Where(x => x.Masa.Numara == masaNumarasi
                && x.BaslangicTarihi == baslangicTarihi
                && x.BitisTarihi == bitisTarihi).FirstOrDefault() ;
            if (rez == null)
                return true;
            Console.WriteLine("uygun rezervasyon bulunamadı !");
            return false;

        }
        // rezervasyon yapılmak istenen masanın, 
        // rezervasyon yapılmak istenen kişi sayısına uygun olup olmadığını 
        // kontrol etmek için bir fonksiyon yazıldı.
        static bool masaVeKisiSayisiKontrol(int masaNumarasi, int rezIcinKisiSayisi) {
            int masaKapasite = masalar[masaNumarasi - 1].KisiSayisi;
            if (masaKapasite < rezIcinKisiSayisi)
            {
                Console.WriteLine("seçmiş olduğunuz masa " + masaKapasite + " kişilik \n " +
                    "lütfen rezervasyon yapmak istediğiniz masayı ya da kişi sayınızı değitirin \n");
                return false;
            }
            return true;
        }
        static bool tarihVeMasaKontrol(DateTime tarih, int masaNumarasi, int rezSaati) {
            List<Rezervasyon> ilgiliGununRezervasyonlari =  rezervasyonlar.Where(x => x.BaslangicTarihi.Day == tarih.Day).ToList();
            if (ilgiliGununRezervasyonlari == null) return true;
            List<Rezervasyon> ilgiliGundekiIlgiliMasaninRezervasyonlari = ilgiliGununRezervasyonlari.Where(z => z.Masa.Numara == masaNumarasi).ToList();
            if (ilgiliGundekiIlgiliMasaninRezervasyonlari == null) return true;
            Rezervasyon rez = ilgiliGundekiIlgiliMasaninRezervasyonlari.FirstOrDefault(d => d.BaslangicTarihi.Hour == rezSaati);
            if (rez == null) return true;
            else {
                Console.WriteLine(" \n Lütfen Farklı bir saat giriniz.");
                return false;
            };
        }
        // rezervasyon alımı için oluşturulan bir metod
        static void rezervasyonBaslat() {
            Console.WriteLine("lütfen Kaç kişilik rezervasyon yapmak istediğinizi seçiniz: )");
            int rezervasyonKisiSayisi = Convert.ToInt32(Console.ReadLine());
            bool mumkunMu, masaKapasiteKontrol, masaVeTarihKontrol;
            int masaNumarasi, rezervasyonBaslangicSaati, rezervasyonTarihiGun, rezervasyonBitisSaati;
            string name, surname;
            // bu while döngüsünde kullanıcıdan aldığımız bilgilere bakarak
            // rezervasyon yapabilmenin mümkün olup olmadığını kontrolEt() fonksiyonunu
            // kullanarak anlarız. kontrolEt fonksiyonu bize true ya da false döner
            // buna göre de bizim while döngümüz ilgili rezervasyon isteğinin mümkün olmasına göre 
            // taa ki mümkün olana kadar tekrarlanır.
            do
            {
                // seçilen rezervasyon masasının kişi sayısına uygun olup olmadığını kontrol ediyoruz.
                do
                {
                    Console.WriteLine("lütfen rezervasyon yapmak istediğiniz masa numarasını seçiniz (1-9)");
                                     masaNumarasi = Convert.ToInt32(Console.ReadLine());
                    masaKapasiteKontrol = masaVeKisiSayisiKontrol(masaNumarasi, rezervasyonKisiSayisi);
                } while (!masaKapasiteKontrol);
                // seçilen tarihte ilgili masanın müsait olup olmadığnı kontrol ediyoruz.
                do
                {
                    Console.WriteLine("lütfen ayın kaçında rezervasyon yapmak istediğiniz yazınız :");
                    rezervasyonTarihiGun = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("lütfen rezervasyon yapmak istediğiniz masa için başlangıç saati seçiniz");
                    rezervasyonBaslangicSaati = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("lütfen rezervasyon yapmak istediğiniz masa için bitiş saati seçiniz");
                    rezervasyonBitisSaati = Convert.ToInt32(Console.ReadLine());
                    DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, rezervasyonTarihiGun, rezervasyonBaslangicSaati, 0, 0);
                    masaVeTarihKontrol = tarihVeMasaKontrol(dt, masaNumarasi, rezervasyonBaslangicSaati);
                } while (!masaVeTarihKontrol);

               
              
                Console.WriteLine("lütfen Adınızı giriniz :");
                 name = Console.ReadLine().ToString();
                Console.WriteLine("lütfen Soyadınız giriniz :");
                 surname = Console.ReadLine().ToString();
                mumkunMu = kontrolEt(masaNumarasi,
                    new DateTime(DateTime.Now.Year, DateTime.Now.Month, rezervasyonTarihiGun, rezervasyonBaslangicSaati, 0, 0),
                    new DateTime(DateTime.Now.Year, DateTime.Now.Month, rezervasyonTarihiGun, rezervasyonBitisSaati, 0, 0));

            } while (!mumkunMu);
           
            
            Rezervasyon rez = new Rezervasyon();
            rez.Masa = new Masa(masaNumarasi, rezervasyonKisiSayisi);
            rez.Musteri = new Musteri(name, surname);
            rez.BaslangicTarihi = new DateTime(DateTime.Now.Year, DateTime.Now.Month, rezervasyonTarihiGun, rezervasyonBaslangicSaati, 0, 0);
            rez.BitisTarihi = new DateTime(DateTime.Now.Year, DateTime.Now.Month, rezervasyonTarihiGun, rezervasyonBitisSaati, 0, 0);
            rezervasyonlar.Add(rez);
        }
        static void Main(string[] args)
        {
            masalariOlustur();
            bool tekrar = false;
            do
            {
                rezervasyonBaslat();
                Console.Clear();
                Console.WriteLine("Yeni bir rezervasyon yapmak ister misniiz ? e/h");
                string cvp = Console.ReadLine().ToString();
                if (cvp == "e")
                    tekrar = true;
            } while (tekrar);
            

            Console.WriteLine("Hello World!");
        }
    }
}
