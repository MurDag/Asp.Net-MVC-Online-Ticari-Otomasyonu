﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class SatisHareket
    {
        [Key]
        public int Satisid { get; set; }
        // ürün
        // cari
        // personel
        public DateTime Tarih { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
        public decimal Toplam { get; set; }

        public virtual Urun Urun { get; set; }
        public int Urunid { get; set; }
        public virtual Cariler Cariler { get; set; }
        public int Cariid { get; set; }
        public virtual Personel Personel { get; set; }
        public int Personelid { get; set; }
        public bool Satis_Durum { get; set; }
    }
}