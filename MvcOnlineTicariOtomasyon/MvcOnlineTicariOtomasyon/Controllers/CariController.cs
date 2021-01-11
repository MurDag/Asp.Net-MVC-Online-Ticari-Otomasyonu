using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        
        Context c = new Context();
       
        public ActionResult Index()
        {
            var degerler = c.Carilers.Where(x => x.Durum == true).ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult CariEkle()
        {
           
            return View();
        }


        [HttpPost]
        public ActionResult CariEkle(Cariler cr)
        {
            c.Carilers.Add(cr);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariSil(int id)
        {
            var deger = c.Carilers.Find(id);
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult CariGetir(int id)
        {
            var cari = c.Carilers.Find(id);
            return View("CariGetir",cari);
        }
        public ActionResult CariGuncelle(Cariler cri)
        {
            if (!ModelState.IsValid)
            {
                return View("CariGetir");
            }
            var cr = c.Carilers.Find(cri.Cariid);
            cr.CariAd = cri.CariAd;
            cr.CariSoyad = cri.CariSoyad;
            cr.CariSehir = cri.CariSehir;
            cr.CariMail = cri.CariMail;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriSatis(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.Cariid == id).ToList();
            var cr = c.Carilers.Where(x => x.Cariid == id).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.cari = cr;
            return View(degerler);
        }
    }
}