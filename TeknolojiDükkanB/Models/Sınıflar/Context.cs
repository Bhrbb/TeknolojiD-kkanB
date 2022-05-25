using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TeknolojiDükkanB.Models.Sınıflar
{
    public class Context:DbContext
    {
        public DbSet<Admin> Adminss { get; set; }
        public DbSet<Cariler> Carilerss { get; set; }
        public DbSet<Departman> Departmanss { get; set; }
        public DbSet<FaturaKalem> FaturaKalemss { get; set; }
        public DbSet<Faturalar> Faturalarss { get; set; }
        public DbSet<Gider> Giderss { get; set; }
        public DbSet<Kategori> Kategoriss { get; set; }
        public DbSet<Personel> Personelss { get; set; }
        public DbSet<SatisHareket> Satishareketss { get; set; }
        public DbSet<Urun> Urunss { get; set; }
        public DbSet<Detay> Detays { get; set; }
        public DbSet<Yapilacaklar> Yapilacaks { get; set; }



    }
}