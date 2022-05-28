using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TeknolojiDükkanB.Models.Sınıflar
{
    public class Personel
    {
        [Key]
        public int PersonelID { get; set; }
        [Display(Name ="Personel Adı")]
        [Column(TypeName = "Varchar")]//veritabanında kısıtlamalar
        [StringLength(20)]

        public string PersonelAd { get; set; }
        [Display(Name ="Personel Soyadı")]
        [Column(TypeName = "Varchar")]//veritabanında kısıtlamalar
        [StringLength(30)]
        public string PersonelSoyad { get; set; }
        [Display(Name ="Personel Görseli")]
        [Column(TypeName = "Varchar")]//veritabanında kısıtlamalar
        [StringLength(200)]
        public string PersonelGorsel { get; set; }
        public ICollection<SatisHareket> satisHarekets { get; set; }
        //her personel birden fazla satyış yapabilir
        public int Departmanid { get; set; }
        public virtual Departman Departman { get; set; }

    }
}