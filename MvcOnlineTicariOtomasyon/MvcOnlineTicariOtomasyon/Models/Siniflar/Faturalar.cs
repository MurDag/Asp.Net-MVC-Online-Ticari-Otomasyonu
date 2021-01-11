using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Faturalar
    {   
        [Key]
        public int Faturaaid { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(1, ErrorMessage = "En fazla 1 karakter girebilirsiniz.")]
       
        public string FaturaSeriNo { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(6, ErrorMessage = "En fazla 6 karakter girebilirsiniz.")]
       
        public string FaturaSıraNo { get; set; }
        public DateTime Tarih { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(60,ErrorMessage ="En fazla 60 karakter girebilirsiniz.")]
        
        public string VergiDairesi { get; set; }

        [Column(TypeName = "char")]
        [StringLength(5, ErrorMessage = "En fazla 60 karakter girebilirsiniz.")]
        public String Saat { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter girebilirsiniz.")]
        
        public string TeslimEden { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter girebilirsiniz.")]
        public string TeslimAlan { get; set; }
        public decimal Toplam { get; set; }
        public ICollection<FaturaKalem> FaturaKalems { get; set; }


    }
}