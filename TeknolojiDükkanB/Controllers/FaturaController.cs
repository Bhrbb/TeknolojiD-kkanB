using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeknolojiDükkanB.Models.Sınıflar;

namespace TeknolojiDükkanB.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura
        Context c = new Context();
        public ActionResult Index()
        {
            var fatura=c.Faturalarss.ToList();
            return View(fatura);
        }
        [HttpGet]
        public ActionResult YeniFatura()
        {
            List<SelectListItem> deger1 = (from x in c.Personelss.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd+""+x.PersonelSoyad,
                                               Value = x.PersonelAd+""+x.PersonelSoyad
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            List<SelectListItem> deger2 = (from x in c.Carilerss.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd+ "" + x.CariSoyad,
                                               Value = x.CariAd+""+x.CariSoyad.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;

            return View();
        }
        [HttpPost]
        public ActionResult YeniFatura(Faturalar f)
        {
            c.Faturalarss.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaGetir(int id )
        {
            List<SelectListItem> deger1 = (from x in c.Personelss.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + "" + x.PersonelSoyad,
                                               Value = x.PersonelAd + "" + x.PersonelSoyad
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            List<SelectListItem> deger2 = (from x in c.Carilerss.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd + "" + x.CariSoyad,
                                               Value = x.CariAd + "" + x.CariSoyad.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;


            var faturagetir =  c.Faturalarss.Find(id);
            return View(faturagetir);
        }
        public ActionResult FaturaGuncelle(Faturalar f)
        {
            var guncelle = c.Faturalarss.Find(f.FaturaID);
            guncelle.FaturaSeriNo = f.FaturaSeriNo;
            guncelle.FaturaSıraNo = f.FaturaSıraNo;
            guncelle.Tarih = f.Tarih;
            guncelle.Saat = f.Saat;
            guncelle.TeslimAlan = f.TeslimAlan;
            guncelle.TeslimEden = f.TeslimEden;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaDetay(int id)
        {
            var faturadetay = c.FaturaKalemss.Where(x => x.FaturaID == id).ToList();
            return View(faturadetay);
        }
    }
}