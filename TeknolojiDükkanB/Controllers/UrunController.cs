using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeknolojiDükkanB.Models.Sınıflar;

namespace TeknolojiDükkanB.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Context c = new Context();

        public ActionResult Index()
        {
            var urun = c.Urunss.Where(x => x.Durum == true).ToList();
            return View(urun);
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> deger1 = (from x in c.Kategoriss.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAdi,
                                               Value = x.KategoriId.ToString()
                                           }).ToList();
            ViewBag.dgr1=deger1;
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(Urun p)
        {
            c.Urunss.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil(int id)
        {
            var deger = c.Urunss.Find(id);
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Kategoriss.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAdi,
                                               Value = x.KategoriId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var urundeger = c.Urunss.Find(id);
            return View("UrunGetir", urundeger);
        }
        public ActionResult UrunGuncelle(Urun urun)
        {
            var guncelle = c.Urunss.Find(urun.UrunID);
            guncelle.UrunMarka = urun.UrunMarka;
            guncelle.UrunGOrsel = urun.UrunGOrsel;
            guncelle.Durum = urun.Durum;
            guncelle.SatisFiyati = urun.SatisFiyati;
            guncelle.Stok = urun.Stok;
            guncelle.UrunAdi = urun.UrunAdi;
            guncelle.AlisFiyati = urun.AlisFiyati;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}