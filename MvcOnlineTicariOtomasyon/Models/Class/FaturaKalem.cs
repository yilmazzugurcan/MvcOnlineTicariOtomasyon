using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Class
{
    public class FaturaKalem
    {
        [Key]
        public int FaturaKalemid { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string  Aciklama { get; set; }
        public int  Miktar { get; set; }
        public decimal  BirimFiyat { get; set; }
        public decimal  Tutar { get; set; }

       
        public int Faturaid { get; set; }


        //1 faturakaleminin sadece bir faturası olabilir
        public virtual Fatura Fatura { get; set; }


    }
}