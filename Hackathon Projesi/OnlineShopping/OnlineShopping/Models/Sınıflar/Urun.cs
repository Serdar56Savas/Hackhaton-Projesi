using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineShopping.Models.Sınıflar
{
    public class Urun
    {
        internal static object urunId;

        [Key]
        public int urunID { get; set; }

        [Column(TypeName="Varchar")]
        [StringLength(30)]
        public string urunAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string marka { get; set; }
        public short stok { get; set; }
        public decimal alisFiyat { get; set; }
        public decimal satisFiyat { get; set; }
        public bool durum { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string UrunGorsel { get; set; }
        public int kategoriid { get; set; }
        public virtual kategori kategori { get; set; }

        public ICollection<SatisHareket> SatisHarekets { get; set; }
    }
}