using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeknolojiDükkanB.Models.Sınıflar;

namespace TeknolojiDükkanB.Controllers
{
    public class GaleriController : Controller
    {
        // GET: Galeri
        Context c=new Context();
        public ActionResult Index()
        {
            var degerler = c.Urunss.ToList();
            return View(degerler);
        }
    }
}