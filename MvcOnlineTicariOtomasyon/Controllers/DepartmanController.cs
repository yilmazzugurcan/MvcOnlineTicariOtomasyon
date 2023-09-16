using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Class;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class DepartmanController : Controller
    {
        // GET: Departman
        Context c = new Context();
        public ActionResult Index()
        {
            //var degerler true olan departmanlar gelecek.
            var degerler = c.Departmans.Where(x => x.Durum == true).ToList();

            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniDepartman()
        {

            List<SelectListItem> deger1 = (from x in c.Departmans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Departmanad,
                                               Value = x.Departmanid.ToString()
                                           }).ToList();


            ViewBag.dgr1 = deger1;
            return View();
        }
        //HTTPGET departmanekle
        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }


        //httppost yenidepartman yarat
        [HttpPost]
        public ActionResult DepartmanEkle(Departman d)
        {
            c.Departmans.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        //departman sil
        public ActionResult DepartmanSil(int id)
        {
            var dep = c.Departmans.Find(id);
            dep.Durum = false;

            c.SaveChanges();
            return RedirectToAction("Index");
        }
        //departman getir
        public ActionResult DepartmanGetir(int id)
        {
            var dep = c.Departmans.Find(id);
            return View("DepartmanGetir", dep);
        }
        //departman güncelle
        public ActionResult DepartmanGuncelle(Departman d)
        {
            var dep = c.Departmans.Find(d.Departmanid);
            dep.Departmanad = d.Departmanad;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        //departman detay
        public ActionResult DepartmanDetay(int id)
        {
            //personel listelemesi yaptır
            var degerler = c.Personels.Where(x => x.Departmanid == id).ToList();
            var dpt = c.Departmans.Where(x => x.Departmanid == id).Select(y => y.Departmanad).FirstOrDefault();
            ViewBag.d = dpt;
            return View(degerler);
        }
        //departman personel satis
        public ActionResult DepartmanPersonelSatis(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.Personelid == id).ToList();
            var per = c.Personels.Where(x => x.PersonelID == id).Select(y => y.PersonelAd + " " + y.PersonelSoyad).FirstOrDefault();
            ViewBag.d = per;
            return View(degerler);
        }


    }
}
