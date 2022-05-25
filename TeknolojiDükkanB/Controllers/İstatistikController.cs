using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeknolojiDükkanB.Models.Sınıflar;

namespace TeknolojiDükkanB.Controllers
{
    public class İstatistikController : Controller
    {
        // GET: İstatistik
        Context c = new Context();
        public ActionResult Index()
        {
            var deger1 = c.Carilerss.Count().ToString();
            ViewBag.d1 = deger1;
            var deger2 = c.Urunss.Count().ToString();
            ViewBag.d2 = deger2;
            var deger3 = c.Personelss.Count().ToString();
            ViewBag.d3 = deger3;
            var deger4 = c.Kategoriss.Count().ToString();
            ViewBag.d4 = deger4;
            var deger5 = c.Urunss.Sum(x => x.Stok).ToString();
            ViewBag.d5 = deger5;
            var deger7 = c.Urunss.Count(x => x.Stok <= 10).ToString();
            ViewBag.d7 = deger7;
            var deger6 = (from x in c.Urunss select x.UrunMarka).Distinct().Count().ToString();
            ViewBag.d6 = deger6;
            //var deger8=c.Urunss.Max(x=>x.SatisFiyati).ToString();
            var deger8 = (from x in c.Urunss orderby x.SatisFiyati descending select x.UrunAdi).FirstOrDefault();
            ViewBag.d8 = deger8;
            var deger9 = (from x in c.Urunss orderby x.SatisFiyati ascending select x.UrunAdi).FirstOrDefault();
            //  var deger9=c.Urunss.Min(x=>x.SatisFiyati).ToString();
            ViewBag.d9 = deger9;
            var deger14 = c.Satishareketss.Sum(x => x.ToplamTutar).ToString();
            ViewBag.d14 = deger14;
            DateTime bugun = DateTime.Now;
            var shortdate = Convert.ToDateTime(bugun.ToShortDateString());
            var deger15 = c.Satishareketss.Count(x => x.Tarih == bugun).ToString();
            ViewBag.d15 = deger15;
            var deger16 = c.Satishareketss.Where(x => x.Tarih == bugun).Sum(y => (decimal?)y.ToplamTutar).ToString();
            ViewBag.d16 = deger16;
            //var deger12 = c.Urunss.GroupBy(x => x.UrunMarka).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            //urunlerı markaya gore gruplandır counta gore a-z sıralandır ilkini getir
            var deger12 = c.Urunss.Where(u => u.UrunID == c.Satishareketss.GroupBy(x => x.UrunID).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault()).Select(k => k.UrunAdi).FirstOrDefault();
            //ıcınde yazan yerde satıs tablosundakılerı urunıd ye gore sıralara z-a sayısına bak ve ilk buldugunu getir 
            //dısında uruns tablosundan getir(iç sorgudan gelen degerinn adını )
            ViewBag.d12 = deger12;
            //TODO BUGUNKI SATISLAR VE BUGUNKI KASA OLMUYOR !

            return View();

        }
        public ActionResult KolayTablolar()
        {
            var sorgu = from x in c.Carilerss
                        group x by x.CariSehir into g
                        select new SinifGrup
                        {
                            Sehir = g.Key,
                            Sayi = g.Count()
                        };

            return View(sorgu.ToList());
        }
        //    public ActionResult YuzdeHesabı()
        //    {
        //        var yuzde = c.Carilerss.Count().ToString();
        //        var yuzde2 = (from x in c.Carilerss select x.CariSehir).Distinct().Count().ToString();
        //        var yuz = (int.Parse(yuzde) / int.Parse(yuzde2)).ToString();
        //        return View(yuzde);

        //    }
        public PartialViewResult Partial1()
        {
            var sorgu2 = from x in c.Personelss
                          group x by x.Departman.DepartmanAdi into g
                          select new SinifGrup2
                          {
                              Departman = g.Key,
                              Sayi = g.Count()
                          };
            return PartialView(sorgu2.ToList());

        }
        public PartialViewResult Partial2()
        {
            var sorgu = c.Carilerss.ToList();
            return PartialView(sorgu);
        }
        public PartialViewResult Partial3()
        {
            var sorgu =c.Urunss.ToList();
            return PartialView(sorgu);
        }
        public PartialViewResult Partial4()
        {
            var sorgu3 = from x in c.Urunss
                         group x by x.UrunMarka into g
                         select new SınıfGrup3
                         {
                             marka=g.Key,
                             sayi=g.Count()
                         };
            return PartialView(sorgu3.ToList());
        }
   
    }
}