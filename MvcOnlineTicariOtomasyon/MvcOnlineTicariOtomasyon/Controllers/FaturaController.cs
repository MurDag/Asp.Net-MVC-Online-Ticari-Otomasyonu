﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura
    
        Context c = new Context(); 
        public ActionResult Index()
        {
            var liste = c.Faturalars.ToList();
            return View(liste);
        }
        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FaturaEkle(Faturalar f)
        {
            c.Faturalars.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaGetir(int id)
        {
            var deger = c.Faturalars.Find(id);
            return View("FaturaGetir", deger);
        }
        public ActionResult FaturaGuncelle(Faturalar f)
        {
            var deger = c.Faturalars.Find(f.Faturaaid);
            deger.FaturaSeriNo = f.FaturaSeriNo;
            deger.FaturaSıraNo = f.FaturaSıraNo;
            deger.VergiDairesi = f.VergiDairesi;
            deger.Tarih = f.Tarih;
            deger.Saat = f.Saat;
            deger.TeslimAlan = f.TeslimAlan;
            deger.TeslimEden = f.TeslimEden;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaDetay(int id)
        {
            
            var deger = c.FaturaKalems.Where(x => x.Faturaaid == id).ToList();
           Session["asd"]= id;
            return View(deger);
        }
        [HttpGet]
        public ActionResult YeniKalem()
        {
           
            return View("YeniKalem");
        }
        [HttpPost]
        public ActionResult YeniKalem(FaturaKalem p)
        {   
            c.FaturaKalems.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}