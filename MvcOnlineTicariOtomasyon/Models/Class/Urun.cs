using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Class
{
    public class Urun
    {

        [Key]
        public int Urunid { get; set; }
        //Kısıtlamalar getirilirken columnda veritipi, stringlenghte karakteruzunluğu girilir.

        [Column(TypeName ="Varchar")]
        [StringLength(30)]
        public string UrunAd { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Marka { get; set; }
        
        public short Stok { get; set; }
        public decimal AlisFiyat { get; set; }
        public decimal SatisFiyat { get; set; }
        public bool Durum { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(300)]
        public string UrunGorsel { get; set; }

        //bir ürünün sadece bir kategorisi olabilir.
        public Kategori Kategori { get; set; }

        public SatisHareket SatisHareket { get; set; }

    }
}