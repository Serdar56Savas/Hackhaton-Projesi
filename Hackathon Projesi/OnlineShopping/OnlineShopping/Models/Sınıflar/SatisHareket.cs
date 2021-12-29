using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShopping.Models.Sınıflar
{
    public class SatisHareket
    {
        [Key]
        public int satisID { get; set; }
        //ürün
        //cari
        //personel
        public DateTime tarih { get; set; }
        public int adet { get; set; }
        public decimal fiyat { get; set; }
        public decimal ToplamTutar { get; set; }
        public int urunid { get; set; }
        public int cariid { get; set; }
        public int personelid { get; set; }
        public virtual Urun Urun { get; set; }
        public virtual Cariler Cariler { get; set; }
        public virtual Personel Personel { get; set; }
    }
}