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
     Masa isminde bir class tanımladık.
     Numara ve Kisi Sayisi isminde 2 field alanı var.
     ve Constructor(yapıcı metodla) Masa class'ından bir 
     instance yapılacağı zaman direkt field'leri 
     parametre olarak istiyor.
         */
    class Masa
    {
        public int Numara { get; set; }
        public int KisiSayisi { get; set; }

        public Masa(int _Numara, int _KisiSayisi)
        {
            Numara = _Numara;
            KisiSayisi = _KisiSayisi;
        }
    }
}
