﻿using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class UrunDetayController : Controller
    {
        // GET: UrunDetay
       
        Context c = new Context();
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            var degerler = c.Uruns.Where(x => x.Urunid == 2);
            cs.Deger1 = c.Uruns.Where(x => x.Urunid == 2).ToList();
            cs.Deger2 = c.Detays.Where(y => y.DetayID == 3).ToList();
            return View(cs);
        }
    }
}