using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineShopping.Models.Sınıflar
{
    public class Cariler
    {
        [Key]
        public int cariID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30,ErrorMessage ="En fazla 30 karakter yazabilirsin")]
        public String cariAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Required(ErrorMessage ="Bu alanı boş geçemezsiniz!")]
        public String cariSoyad { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public String cariSehir { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public String cariMail { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public String cariSifre { get; set; }

        public bool durum { get; set; }

        public ICollection<SatisHareket> SatisHarekets { get; set; }
    }
}