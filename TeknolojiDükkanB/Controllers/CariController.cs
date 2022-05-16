using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeknolojiDükkanB.Models.Sınıflar;

namespace TeknolojiDükkanB.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        Context c= new Context();
        public ActionResult Index()
        {
            var listele = c.Carilerss.Where(x=>x.Durum==true).ToList();
            return View(listele);
        }
        [HttpGet]
        public ActionResult YeniCari()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniCari(Cariler cari)
        {
            cari.Durum= true;
            c.Carilerss.Add(cari);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
          var caribul=  c.Carilerss.Find(id);
            caribul.Durum= false;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Getir(int id)
        {
            var cari = c.Carilerss.Find(id);
            return View("CariGetir",cari);
        }
        public ActionResult CariGuncelle(Cariler cari)
        {
            if (!ModelState.IsValid)
            {
                return View("CariGetir");
            }
            var cariguncelle = c.Carilerss.Find(cari.CariID);
            cariguncelle.CariAd = cari.CariAd;
            cariguncelle.CariSoyad = cari.CariSoyad;
            cariguncelle.CariSehir = cari.CariSehir;
            cariguncelle.CariMail = cari.CariMail;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MsteriSatis(int id)
        {
            var musteri= c.Satishareketss.Where(x=>x.CariID==id).ToList();
            var cr = c.Carilerss.Where(x => x.CariID == id).Select(y => y.CariAd + "" + y.CariSoyad).FirstOrDefault();
            ViewBag.cari = cr;
            return View(musteri);
        }
    }
}