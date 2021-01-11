using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;


namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
       
        Context c = new Context();
        public ActionResult Index()
        {
            var deger = c.SatisHarekets.Where(x => x.Satis_Durum == true).ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            List<SelectListItem> deger1 = (from x in c.Uruns.Where(x=>x.Durum==true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Urunad,
                                               Value = x.Urunid.ToString()
                                           }).ToList();
            

            List<SelectListItem> deger2 = (from x in c.Carilers.Where(x=>x.Durum==true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd+" "+x.CariSoyad,
                                               Value = x.Cariid.ToString()
                                           }).ToList();

            List<SelectListItem> deger3 = (from x in c.Personels.Where(x=>x.Durum==true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd+" "+x.PersonelSoyad,
                                               Value = x.Personelid.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(SatisHareket s)
        {
            s.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SatisHarekets.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SatisSil(int id)
        {
            bool a = false;
            var deger = c.SatisHarekets.Find(id);
            deger.Satis_Durum = a;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult SatisGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Uruns.Where(x => x.Durum == true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Urunad,
                                               Value = x.Urunid.ToString()
                                           }).ToList();


            List<SelectListItem> deger2 = (from x in c.Carilers.Where(x => x.Durum == true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd + " " + x.CariSoyad,
                                               Value = x.Cariid.ToString()
                                           }).ToList();

            List<SelectListItem> deger3 = (from x in c.Personels.Where(x => x.Durum == true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.Personelid.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;

            var degerler = c.SatisHarekets.Find(id);
            return View("SatisGetir",degerler);
        }
        public ActionResult SatisGuncelle(SatisHareket s)
        {
            
            var deger = c.SatisHarekets.Find(s.Satisid);
            var deger2 = c.Uruns.Find(s.Urunid);
            int v= deger2.Stok-(s.Adet - deger.Adet);
            deger2.Stok = (short)v;

            deger.Cariid = s.Cariid;
            deger.Adet = s.Adet;
            deger.Fiyat = s.Fiyat;
            deger.Personelid = s.Personelid;
            deger.Tarih = s.Tarih;
            deger.Toplam = s.Toplam;
            deger.Urunid = s.Urunid;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SatisDetay(int id)
        {
            var deger = c.SatisHarekets.Where(x => x.Satisid == id).ToList();
            return View("SatisDetay", deger);
        }
        
    }
}