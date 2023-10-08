using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Class;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura
        Context c = new Context();

        //fix System.InvalidOperationException: 'The 'Saat' property on 'Fatura' could not be set to a 'System.String' value. You must set this property to a non-null value of type 'System.DateTime'. '
        //public DateTime Saat { get; set; }
        //public string Saat { get; set; }


        public FaturaController() {
        
        
        }

        public ActionResult Index()
        {
            var degerler = c.Faturas.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FaturaEkle(Fatura f)
        {
            c.Faturas.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaGetir(int id)
        {
            var ftr = c.Faturas.Find(id);
            return View("FaturaGetir", ftr);
        }

        public ActionResult FaturaGuncelle(Fatura f)
        {
            var ftr = c.Faturas.Find(f.Faturaid);
            ftr.FaturaSeriNo = f.FaturaSeriNo;
            ftr.FaturaSiraNo = f.FaturaSiraNo;
            ftr.VergiDairesi = f.VergiDairesi;
            ftr.Saat = f.Saat;
            ftr.Tarih = f.Tarih;
            ftr.TeslimAlan = f.TeslimAlan;
            ftr.TeslimEden = f.TeslimEden;
            ftr.Toplam = f.Toplam;
            ftr.Saat = f.Saat;
            ftr.TeslimEden = f.TeslimEden;
            ftr.TeslimAlan = f.TeslimAlan;
            ftr.VergiDairesi = f.VergiDairesi;
            ftr.Faturaid = f.Faturaid;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaDetay(int id)
        {
            var degerler = c.FaturaKalems.Where(x => x.FaturaKalemid == id).ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniKalem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKalem(FaturaKalem f)
        {
            c.FaturaKalems.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult KalemGuncelle(int id)
        {
            var deger = c.FaturaKalems.Find(id);
            return View(deger);
        }
        [HttpPost]
        public ActionResult KalemGuncelle(FaturaKalem f)
        {
            var deger = c.FaturaKalems.Find(f.FaturaKalemid);
            deger.Aciklama = f.Aciklama;
            deger.BirimFiyat = f.BirimFiyat;
            deger.Faturaid = f.Faturaid;
            deger.Miktar = f.Miktar;
            deger.Tutar = f.Tutar;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
            public ActionResult KalemSil(int id)
        {
            var deger = c.FaturaKalems.Find(id);
            c.FaturaKalems.Remove(deger);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult DinamikEkle(FaturaKalem f)
        {
            c.FaturaKalems.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult DinamikSil(int id)
        {
            var deger = c.FaturaKalems.Find(id);
            c.FaturaKalems.Remove(deger);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult DinamikGuncelle(FaturaKalem f)
        {
            var deger = c.FaturaKalems.Find(f.FaturaKalemid);
            deger.Aciklama = f.Aciklama;
            deger.BirimFiyat = f.BirimFiyat;
            deger.Faturaid = f.Faturaid;
            deger.Miktar = f.Miktar;
            deger.Tutar = f.Tutar;
            c.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}