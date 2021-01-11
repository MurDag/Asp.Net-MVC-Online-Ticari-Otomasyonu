using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
       
        Context c = new Context();
        // GET: Personel
        public ActionResult Index()
        {
            var degerler = c.Personels.Where(x => x.Durum == true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> deger1 = (from x in c.Departmans.Where(x=>x.Durum==true)
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAd,
                                               Value = x.Departmanid.ToString()
                                           }).ToList();

            ViewBag.dgr1 = deger1;


            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {

            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelSil(int id)
        {
            var deger = c.Personels.Find(id);
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Departmans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAd,
                                               Value = x.Departmanid.ToString()
                                           }).ToList();

            ViewBag.dpr1 = deger1;

            var deger = c.Personels.Find(id);
            return View("PersonelGetir",deger);
        }
        public ActionResult PersonelGuncelle(Personel p)
        {
            if (!ModelState.IsValid)
            {
                
                List<SelectListItem> deger1 = (from x in c.Departmans.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.DepartmanAd,
                                                   Value = x.Departmanid.ToString()
                                               }).ToList();

                ViewBag.dpr1 = deger1;

               
                return View("PersonelGetir", c.Personels.Find(p.Personelid));
            }
            var deger = c.Personels.Find(p.Personelid);
            deger.PersonelAd = p.PersonelAd;
            deger.PersonelSoyad = p.PersonelSoyad;
            deger.PersonelGorsel = p.PersonelGorsel;
            deger.Departmanid = p.Departmanid;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelListe()
        {
            var sorgu = c.Personels.Where(x => x.Durum == true).ToList();
            return View(sorgu);
        }
    }
}