using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineShopping.Models.Sınıflar
{
    public class Faturalar
    {
        [Key]
        public int faturaID { get; set; }

        [Column(TypeName = "char")]
        [StringLength(1)]
        public string faturaSeriNo { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string faturaSıraNo { get; set; }
        public DateTime tarih { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string VergiDairesi { get; set; }

        [Column(TypeName = "char")]
        [StringLength(10)]
        public string saat { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string teslimEden { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string teslimAlan { get; set; }

        public decimal Toplam { get; set; }
        public ICollection<FaturaKalem> FaturaKalems { get; set; }

    }
}