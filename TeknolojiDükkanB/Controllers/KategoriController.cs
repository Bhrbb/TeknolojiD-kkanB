using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeknolojiDükkanB.Models.Sınıflar;

namespace TeknolojiDükkanB.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        Context c= new Context();

        public ActionResult Index()
        {
            var degerler=c.Kategoriss.ToList();
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
    }
}