using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeknolojiDükkanB.Models.Sınıflar;

namespace TeknolojiDükkanB.Controllers
{
    public class DepartmanController : Controller
    {
        // GET: Departman
        Context c=new Context();
        public ActionResult Index()
        {
            var degerler = c.Departmanss.Where(x=>x.Durum==true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult Yeni()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Yeni(Departman d)
        {
            d.Durum = true;
            c.Departmanss.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanSil(int id)
        {
            var dep = c.Departmanss.Find(id);
            dep.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
       
        public ActionResult DepartmanGetir(int id)
        {
            var getir = c.Departmanss.Find(id);
            return View("DepartmanGetir", getir);
        }
        public ActionResult DepartmanGuncelle(Departman dep)
        {
            var depg = c.Departmanss.Find(dep.DepartmanID);
            depg.DepartmanAdi = dep.DepartmanAdi;
            depg.Durum = true;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanDetay(int id)
        {
            var personel = c.Personelss.Where(x => x.Departmanid == id).ToList();
            var depdt = c.Departmanss.Where(x => x.DepartmanID == id).Select(y => y.DepartmanAdi).FirstOrDefault();
            ViewBag.d = depdt;
            return View(personel);
        }
       public ActionResult DepartmanPersonelSatis(int id)
       {
            var degerler = c.Satishareketss.Where(x => x.personelID == id).ToList();
            var per = c.Personelss.Where(x => x.PersonelID == id).Select(y => y.PersonelAd + " " + y.PersonelSoyad).FirstOrDefault();
            ViewBag.dpers = per;
            return View(degerler);
       }
    }
}