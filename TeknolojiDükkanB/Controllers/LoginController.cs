using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TeknolojiDükkanB.Models.Sınıflar;

namespace TeknolojiDükkanB.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        Context c= new Context();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult Partial2()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Partial2(Cariler p)
        {
            c.Carilerss.Add(p);
            c.SaveChanges();
            return PartialView();
        }
        [HttpGet]
        public ActionResult CariLogin1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CariLogin1(Cariler cari)
        {
            var bilgiler = c.Carilerss.FirstOrDefault(x => x.CariMail == cari.CariMail && x.Sifre == cari.Sifre);
            if (bilgiler!=null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.CariMail, false);
                Session["CariMail"]=bilgiler.CariMail.ToString();
                return RedirectToAction("Index","CariPanel");
            }
            else
                return View();
          
        }
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();

        }
        [HttpPost]
        public ActionResult AdminLogin(Admin a)
        {
            var admin=c.Adminss.FirstOrDefault
                (x=>x.KullaniciAd==a.KullaniciAd && x.Sifre==a.Sifre);
            if (admin!=null)
            {
                FormsAuthentication.SetAuthCookie(admin.KullaniciAd, false);
                Session["KullanıcıAd"]=admin.KullaniciAd.ToString();
                return RedirectToAction("Index", "Kategori");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
             
        }
    }
}