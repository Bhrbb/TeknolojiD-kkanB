using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeknolojiDükkanB.Models.Sınıflar;
using PagedList;
using PagedList.Mvc;

namespace TeknolojiDükkanB.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        Context c= new Context();

        public ActionResult Index(int sayfa=1)
        {
            var degerler=c.Kategoriss.ToList().ToPagedList(sayfa,12);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(Kategori k)
        {
            c.Kategoriss.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriSil(int ID)
        {

            var kategory = c.Kategoriss.Find(ID);
            c.Kategoriss.Remove(kategory);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int ID)
        {
            var kategori = c.Kategoriss.Find(ID);
            return View("KategoriGetir",kategori);
        }
        public ActionResult KategoriGuncelleme(Kategori k)
        {
            var guncelle = c.Kategoriss.Find(k.KategoriId);
            guncelle.KategoriAdi = k.KategoriAdi;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}