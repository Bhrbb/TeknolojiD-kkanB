using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TeknolojiDükkanB.Models.Sınıflar
{
    public class Yapilacaklar
    {
        [Key]
        public int YapilacakID { get; set; }
        
        [Column(TypeName = "Varchar")]//veritabanında kısıtlamalar
        [StringLength(100)]
        public string Baslik { get; set; }
       
        [Column(TypeName = "bit")]//veritabanında kısıtlamalar
        public bool Durum { get; set; }
        
        
        
    }
}