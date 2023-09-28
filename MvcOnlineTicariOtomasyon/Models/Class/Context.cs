using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcOnlineTicariOtomasyon.Models.Class
{
    public class Context : DbContext
        //DB komutlarını kullanabılmek ıcın dbcontext sınıfından miras alınması gerekiyor.
    {
        //tablolara buradan sql'e yansıtıcaz ve tablolara buradan ulaşıcağız.
        //dbset tablo bazlı çalışılacağı için veri tipi dbset olacak
        //sınıf ve tablo isimleri karışmaması için sonuna s takısını koyduk
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Cariler> Carilers { get; set; }
        public DbSet<Departman> Departmans { get; set; }
        public DbSet<FaturaKalem> FaturaKalems { get; set; }
        public DbSet<Fatura> Faturas { get; set; }
        public DbSet<Gider> Giders { get; set; }
        public DbSet<Kategori> Kategoris { get; set; }
        public DbSet<Personel> Personels { get; set; }
        public DbSet<SatisHareket> SatisHarekets { get; set; }
        public DbSet<Urun> Uruns { get; set; }

    }
   
}