using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineShopping.Models.Sınıflar
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string kullaniciAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string sifre { get; set; }

        [Column(TypeName = "char")]
        [StringLength(1)]
        public string yetki { get; set; }
    }
}