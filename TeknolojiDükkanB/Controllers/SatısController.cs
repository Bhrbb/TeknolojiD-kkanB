using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeknolojiDükkanB.Models.Sınıflar;

namespace TeknolojiDükkanB.Controllers
{
    public class SatısController : Controller
    {
        // GET: Satıs
        Context c= new Context();
        public ActionResult Index()
        { 
            var degerler=c.Satishareketss.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            List<SelectListItem>deger1=(from x in c.Urunss.ToList()
                                       select new SelectListItem
                                       {
                                           Text=x.UrunAdi,
                                           Value=x.UrunID.ToString()
                                       }).ToList();
            ViewBag.dgr1 = deger1;
            List<SelectListItem> deger2= (from x in c.Carilerss.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd+""+ x.CariSoyad,
                                               Value = x.CariID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            List<SelectListItem> deger3 = (from x in c.Personelss.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd+""+x.PersonelSoyad,
                                               Value = x.PersonelID.ToString()
                                           }).ToList();
            ViewBag.dgr3 = deger3;
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(SatisHareket satis)
        {
           // satis.Tarih=DateTime.Parse(DateTime.Now.ToShortDateString());
          satis.Tarih=DateTime.Now;
            c.Satishareketss.Add(satis);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatisGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Urunss.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UrunAdi,
                                               Value = x.UrunID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            List<SelectListItem> deger2 = (from x in c.Personelss.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + "" + x.PersonelSoyad,
                                               Value = x.PersonelID.ToString()
                                           }).ToList();
            ViewBag.dgr2=deger2;
            List<SelectListItem> deger3 = (from x in c.Carilerss.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd + "" + x.CariSoyad,
                                               Value = x.CariID.ToString()

                                           }).ToList();
            ViewBag.dgr3=deger3;
            var satisgetir = c.Satishareketss.Find(id);
            return View("SatisGetir", satisgetir);
        }
        public ActionResult SatisGuncelle(SatisHareket satis)
        {
            var satisguncelle=c.Satishareketss.Find(satis.SatisID);
            satisguncelle.UrunID = satis.UrunID;
            satisguncelle.CariID = satis.CariID;
            satisguncelle.Fiyat = satis.Fiyat;
            satisguncelle.ToplamTutar = satis.ToplamTutar;
            satisguncelle.personelID = satis.personelID;
            satisguncelle.Adet=satis.Adet;
            satisguncelle.Tarih=satis.Tarih;
            c.SaveChanges();
            return RedirectToAction("Index");


        }
        public ActionResult SatisDetay(int id)
        {
            var degerler = c.Satishareketss.Where(x => x.SatisID == id).ToList();
            return View(degerler);
        }
    }
}