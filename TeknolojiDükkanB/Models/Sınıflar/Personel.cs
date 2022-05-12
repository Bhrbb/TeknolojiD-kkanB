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
        [Column(TypeName = "Varchar")]//veritabanında kısıtlamalar
        [StringLength(20)]
        public string PersonelAd { get; set; }
        [Column(TypeName = "Varchar")]//veritabanında kısıtlamalar
        [StringLength(30)]
        public string PersonelSoyad { get; set; }
        [Column(TypeName = "Varchar")]//veritabanında kısıtlamalar
        [StringLength(200)]
        public string PersonelGorsel { get; set; }
        public ICollection<SatisHareket> satisHarekets { get; set; }
        //her personel birden fazla satyış yapabilir
        public Departman Departman { get; set; }

    }
}