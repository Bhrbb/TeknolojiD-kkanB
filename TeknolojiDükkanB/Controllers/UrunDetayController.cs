﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeknolojiDükkanB.Models.Sınıflar;

namespace TeknolojiDükkanB.Controllers
{
    public class UrunDetayController : Controller
    {
        // GET: UrunDetay
        Context c= new Context();
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger1 = c.Urunss.Where(x => x.UrunID == 1).ToList();
            cs.Deger2 = c.Detays.Where(x => x.DetayId == 1).ToList();
            var degerler=c.Urunss.Where(x=>x.UrunID==1).ToList();
            return View(cs);
        }
    }
}