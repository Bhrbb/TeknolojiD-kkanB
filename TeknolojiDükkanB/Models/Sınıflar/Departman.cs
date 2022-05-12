using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TeknolojiDükkanB.Models.Sınıflar
{
    public class Departman
    { 
        [Key]
        public int DepartmanID { get; set; }
        [Column(TypeName = "Varchar")]//veritabanında kısıtlamalar
        [StringLength(30)]
        public string DepartmanAdi { get; set; }
        public ICollection<Personel> personels { get; set; }

    }
}