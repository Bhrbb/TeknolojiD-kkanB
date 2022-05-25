using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeknolojiDükkanB.Controllers;
using TeknolojiDükkanB.Models.Sınıflar;

namespace TeknolojiDükkanB.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        Context c = new Context();
        public ActionResult Index()
        {
            var personel = c.Personelss.ToList();
            return View(personel);
        }
        [HttpGet]
        public ActionResult YeniPersonel()
        {
            List<SelectListItem> deger1 = (from x in c.Departmanss.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAdi,
                                               Value = x.DepartmanID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult YeniPersonel(Personel p)
        {
             c.Personelss.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");   

        }
        public ActionResult PersonelGetir(int id)
        {
            var personelbul = c.Personelss.Find(id);
            List<SelectListItem> deger1 = (from x in c.Departmanss.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAdi,
                                               Value = x.DepartmanID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            return View("PersonelGetir",personelbul);
           

        }
        public ActionResult PersonelGuncelle(Personel p)
        {
            var personel = c.Personelss.Find(p.PersonelID);
            personel.PersonelAd = p.PersonelAd;
            personel.PersonelSoyad = p.PersonelSoyad;
            personel.Departmanid = p.Departmanid;
            personel.PersonelGorsel=p.PersonelGorsel;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Personelliste()
        {
            var sorgu = c.Personelss.ToList();
            return View(sorgu);
        }
    }
}