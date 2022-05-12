using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TeknolojiDükkanB.Models.Sınıflar
{
    public class Admin
    {
        [Key]
       
        public int AdminID { get; set; }
        [Column(TypeName = "Varchar")]//veritabanında kısıtlamalar
        [StringLength(10)]
        public string KullaniciAd { get; set; }
        [Column(TypeName = "Varchar")]//veritabanında kısıtlamalar
        [StringLength(30)]
        public string Sifre { get; set; }
        [Column(TypeName = "char")]//veritabanında kısıtlamalar
        [StringLength(1)]
        public string Yetki { get; set; }

    }
}