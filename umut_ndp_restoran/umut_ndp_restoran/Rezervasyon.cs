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
        Rezervasyon isminde bir class tanımladık.
        rezervasyon müşteri, masa, başlangıç ve bitiş tarihlerini barındırıyor

    */
    class Rezervasyon
    {
        public Musteri Musteri { get; set; }
        public Masa Masa { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
    }
}
