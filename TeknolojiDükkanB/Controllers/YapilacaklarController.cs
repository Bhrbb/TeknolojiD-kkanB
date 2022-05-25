using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeknolojiDükkanB.Models.Sınıflar;

namespace TeknolojiDükkanB.Controllers
{
    public class YapilacaklarController : Controller
    {
        // GET: Yapilacaklar
        Context c= new Context();
        public ActionResult Index()
        {
            var deger1 = c.Carilerss.Count().ToString();
            ViewBag.d1 = deger1;
            var deger2= c.Urunss.Sum(x => x.Stok).ToString();
            ViewBag.d2=deger2;
            var deger3=c.Kategoriss.Count().ToString();
            ViewBag.d3=deger3;
            var deger4 = (from x in c.Carilerss select x.CariSehir).Distinct().Count().ToString();
            ViewBag.d4=deger4;
            return View();
        }
    }
}