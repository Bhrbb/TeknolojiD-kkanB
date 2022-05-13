using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TeknolojiDükkanB.Models.Sınıflar
{
    public class Urun
    {
        [Key]
        public int UrunID { get; set; }

        [Column(TypeName="Varchar")]//veritabanında kısıtlamalar
        [StringLength(30)]
        public string UrunAdi { get; set; }
        [Column(TypeName = "Varchar")]//veritabanında kısıtlamalar
        [StringLength(30)]
        public string UrunMarka { get; set; }
        public short Stok { get; set; }
        public decimal AlisFiyati { get; set; }
        public decimal SatisFiyati { get; set; }
        public bool Durum { get; set; }
        [Column(TypeName = "Varchar")]//veritabanında kısıtlamalar
        [StringLength(150)]
        public string UrunGOrsel { get;set; }
        //bır urünün bir kategorisi olabliir
        public int kategoriid { get; set; }
        public virtual Kategori Kategori { get; set; }
        public ICollection<SatisHareket> satisHarekets { get; set; }
        //bır ürün birden fazla kez satışta bulunabilir

    }
}