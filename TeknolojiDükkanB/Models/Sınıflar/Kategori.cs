using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TeknolojiDükkanB.Models.Sınıflar
{
    public class Kategori
    {
        [Key]
        public int KategoriId { get; set; }
        [Column(TypeName = "Varchar")]//veritabanında kısıtlamalar
        [StringLength(30)]
        public string KategoriAdi { get; set; }

        //her kategoride bırden fazla urun vardır 
        //1den cok ilişki
        public ICollection<Urun> Uruns { get; set; }


    }
}