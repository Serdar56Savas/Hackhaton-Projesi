using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShopping.Models.Sınıflar;
namespace OnlineShopping.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.SatisHarekets.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            List<SelectListItem> deger1 = (from x in c.Uruns.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.urunAd,
                                               Value = x.urunID.ToString()

                                           }).ToList();

            List<SelectListItem> deger2 = (from x in c.Carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.cariAd +" " + x.cariSoyad,
                                               Value = x.cariID.ToString()

                                           }).ToList();

            List<SelectListItem> deger3 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.personelAd +" "+ x.personelSoyad,
                                               Value = x.personelID.ToString()

                                           }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            return View(); //view yüklenince geti çalıştır
        }
        [HttpPost]
        public ActionResult YeniSatis(SatisHareket s)
        {
            s.tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SatisHarekets.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult SatisGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Uruns.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.urunAd,
                                               Value = x.urunID.ToString()

                                           }).ToList();

            List<SelectListItem> deger2 = (from x in c.Carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.cariAd + " " + x.cariSoyad,
                                               Value = x.cariID.ToString()

                                           }).ToList();

            List<SelectListItem> deger3 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.personelAd + " " + x.personelSoyad,
                                               Value = x.personelID.ToString()

                                           }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            var deger = c.SatisHarekets.Find(id);
            return View("SatisGetir", deger);
        }
        public ActionResult SatisGuncelle(SatisHareket p)
        {
            var deger = c.SatisHarekets.Find(p.satisID);
            deger.cariid = p.cariid;
            deger.adet = p.adet;
            deger.fiyat = p.fiyat;
            deger.personelid = p.personelid;
            deger.tarih = p.tarih;
            deger.ToplamTutar = p.ToplamTutar;
            deger.urunid = p.urunid;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatisDetay(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.satisID == id).ToList();
            return View(degerler);
        }
    }
}