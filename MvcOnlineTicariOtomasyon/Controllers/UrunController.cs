using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Class;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Context c = new Context();
        public ActionResult Index()
        {
            var urunler = c.Uruns.Where(x => x.Durum == true).ToList();
            return View(urunler);
        }
        [HttpGet]
        public ActionResult YeniUrun() //ekran yüklendiğinde de çalışacak
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text=x.KategoriAd,
                                               Value=x.KategoriID.ToString()
                                           }).ToList();

            ViewBag.dgr1=deger1;
            return View();
        }

        [HttpPost]
        public ActionResult YeniUrun(Urun p)
        {
            c.Uruns.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunSil(int id)
        {

            var urn = c.Uruns.Find(id);
            urn.Durum = false;

            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString()
                                           }).ToList();

            ViewBag.dgr1 = deger1;
            var urundeger = c.Uruns.Find(id);
            return View("UrunGetir", urundeger);

        }

        public ActionResult UrunGuncelle(Urun p)
        {
            //ktgr isimli bir değişken oluşturulup sayfadaki id hafızaya alındı
            //yeni değer seçilen idye atanmış oldu
            var urn = c.Uruns.Find(p.Urunid);
            urn.Durum = p.Durum;
            urn.AlisFiyat = p.AlisFiyat;
            urn.Kategoriid=p.Kategoriid;
            urn.Marka = p.Marka;
            urn.SatisFiyat = p.SatisFiyat;
            urn.UrunGorsel = p.UrunGorsel;
            urn.Stok = p.Stok;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}