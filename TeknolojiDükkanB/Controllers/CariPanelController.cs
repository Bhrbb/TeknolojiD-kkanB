using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeknolojiDükkanB.Models.Sınıflar;

namespace TeknolojiDükkanB.Controllers
{
    public class CariPanelController : Controller
    {
        // GET: CariPanel
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CariMail"];
            var degerler = c.Carilerss.FirstOrDefault(x => x.CariMail == mail);
            ViewBag.m = mail;
            return View(degerler);
        }
        public ActionResult Siparis()
        {
            var mail = (string)Session["CariMail"];
            var id=c.Carilerss.Where(x => x.CariMail == mail.ToString()).Select(y=>
            y.CariID).FirstOrDefault();
            var siparis=c.Satishareketss.Where(x=>x.CariID==id).ToList();
            return View(siparis);
        }
       
    }
}