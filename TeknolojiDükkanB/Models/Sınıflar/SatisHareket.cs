using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeknolojiDükkanB.Models.Sınıflar
{
    public class SatisHareket
    {
        [Key]
        public int SatisID { get; set; }
        //urun,cari,personel
        public DateTime Tarih { get; set; }
        public decimal Fiyat { get; set; }
        public int Adet { get; set; }
        public decimal ToplamTutar { get; set; }
        public int UrunID { get; set; }
        public virtual Urun urun { get; set; }
        public int CariID { get;set; }
        public  virtual Cariler cariler { get; set; }
        public int personelID { get; set; }
        public virtual  Personel personel { get; set; }
       
    }
}