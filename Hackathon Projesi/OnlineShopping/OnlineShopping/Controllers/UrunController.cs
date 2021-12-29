using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShopping.Models.Sınıflar;
namespace OnlineShopping.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Context c = new Context();
        [Authorize]
        public ActionResult Index(string p)
        {
            var urunler = from x in c.Uruns select x;
            if(!string.IsNullOrEmpty(p))
            {
                urunler = urunler.Where(y=>y.urunAd.Contains(p));
            }
            return View(urunler.ToList());

        }
        [HttpGet]
        [Authorize]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.kategoriAd,
                                               Value = x.kategoriID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        [Authorize]
        public ActionResult YeniUrun(Urun p)
        {
            c.Uruns.Add(p); //bir butona tıklayınca postu çalıştır
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult UrunSil(int id)
        {
            var ur = c.Uruns.Find(id);
            c.Uruns.Remove(ur);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.kategoriAd,
                                               Value = x.kategoriID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            var urundeger = c.Uruns.Find(id);
            return View("UrunGetir", urundeger);
        }
        public ActionResult UrunGuncelle(Urun p)
        {
            var uru = c.Uruns.Find(p.urunID);
            uru.urunAd = p.urunAd;
            uru.kategoriid = p.kategoriid;
            uru.alisFiyat = p.alisFiyat;
            uru.satisFiyat = p.satisFiyat;
            uru.durum = p.durum;
            uru.stok = p.stok;
            uru.marka = p.marka;
            uru.UrunGorsel = p.UrunGorsel;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunListele()
        {
            var degerler = c.Uruns.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult SatisYap(int id)
        {
            List<SelectListItem> deger3 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.personelAd + " " + x.personelSoyad,
                                               Value = x.personelID.ToString()
                                           }).ToList();

            ViewBag.dgr3 = deger3;
            var deger1 = c.Uruns.Find(id);
            ViewBag.dgr1 = deger1.urunID;
            ViewBag.dgr2 = deger1.satisFiyat;
            return View();
        }
        [HttpPost]
        public ActionResult SatisYap(SatisHareket p)
        {
            return View();
        }
    }
}