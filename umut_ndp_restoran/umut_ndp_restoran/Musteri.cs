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
using System.Text;

namespace umut_ndp_restoran
{
    /*
     Müşteri isminde bir class tanımladık.
     bu class'ın içinde 2 adet constructor(yapıcı metod)
     tanımlandı. isteğe bağlı olarak yeni bir instance 
     yaratıldığında Name ve Surname alanları parametre olarak
     gönderilip. Yeni bi instance oluşturulabilir.
         */
    class Musteri
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public Musteri()
        {

        }
        public Musteri(string _name, string _surname)
        {
            Name = _name;
            Surname = _surname;

        }
    }
}
